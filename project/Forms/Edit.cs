using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Edit : Form
    {
        private SQLiteConnection connection;
        private int exhibitionId; 
        private string tempImagePath = "";
        public Edit(int exhibitionId, string dbPath)
        {
            InitializeComponent();
            this.exhibitionId = exhibitionId;
            connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            connection.Open();

            LoadExhibitionData();
             
        }
        //  прям очень нужно вернуться к этому, сама не поняла что сделала
        public Edit(Exhibition selectedExhibition)
        {
        }

        public Edit()
        {
        }

        private void LoadExhibitionData()
        {
            string query = "SELECT Title, ExhibitionDate, Photo FROM Exhibitions WHERE ExhibitionID = @Id";
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Id", exhibitionId);

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        dtpDate.Value = DateTime.Parse(reader["ExhibitionDate"].ToString());

                        if (reader["Photo"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])reader["Photo"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                picCover.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выставка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
         
        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tempImagePath = openFileDialog.FileName;
                picCover.Image = Image.FromFile(tempImagePath); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Название выставки не может быть пустым", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] newImageData = null;

                if (!string.IsNullOrEmpty(tempImagePath))
                {
                    newImageData = File.ReadAllBytes(tempImagePath);
                }
                else if (picCover.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picCover.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        newImageData = ms.ToArray();
                    }
                }
                string updateQuery = @"
            UPDATE Exhibitions 
            SET Title = @Title, 
                ExhibitionDate = @Date, 
                Photo = @Photo 
            WHERE ExhibitionID = @Id";

                using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Photo", newImageData ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Id", exhibitionId);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Изменения сохранены!", "Успех",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditExhibitionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection?.Close();
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }
    }
}
         
  




