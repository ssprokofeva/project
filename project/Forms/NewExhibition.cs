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
    public partial class NewExhibition : Form
    {
        private SQLiteConnection connection;
        private string dbPath = "YourDatabase.sqlite";
        private string selectedImagePath = "";

        public NewExhibition()
        {
            InitializeComponent();
            ConnectToDatabase();
        }
        private void ConnectToDatabase()
        {
            connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            connection.Open();
        }


         

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                MessageBox.Show("Изображение выбрано: " + Path.GetFileName(selectedImagePath), "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExhibitionName.Text))
            {
                MessageBox.Show("Введите название выставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] imageBytes = null;

                // Если файл выбран, конвертируем его в BLOB
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    imageBytes = File.ReadAllBytes(selectedImagePath);
                }

                
                string insertQuery = @"
            INSERT INTO Exhibitions (Title, ExhibitionDate, Photo)
            VALUES (@Title, @Date, @Photo)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", txtExhibitionName.Text);
                    command.Parameters.AddWithValue("@Date", dtpExhibition.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Photo", imageBytes ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Выставка сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка формы
                txtExhibitionName.Clear();
                selectedImagePath = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
