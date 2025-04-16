using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        private List<Exhibition> exhibitions = new List<Exhibition>();
        private Dictionary<PictureBox, Exhibition> pictureBoxToExhibitionMap = new Dictionary<PictureBox, Exhibition>();
        private Exhibition selectedExhibition = null;
        private string dbPath = "ExhibitionsDB.sqlite";

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadExhibitions();
            InitializePictureBoxes();
        }
        private void InitializePictureBoxes()
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>
        {
            pictureBox, pictureBox2, pictureBox3,
            pictureBox4, pictureBox5, pictureBox6
        };

            foreach (var pb in pictureBoxes)
            {
                pb.Cursor = Cursors.Hand;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BorderStyle = BorderStyle.None;
                pb.Click += PictureBox_Click;
            }
        }
        private void SetupDataGridView()
        {
            dataGridViewExhibitions.AutoGenerateColumns = false;
            dataGridViewExhibitions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewExhibitions.MultiSelect = false;

            dataGridViewExhibitions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });
            dataGridViewExhibitions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Название",
                Width = 150
            });
            dataGridViewExhibitions.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Дата",
                Width = 100
            });

            dataGridViewExhibitions.CellClick += DataGridViewExhibitions_CellClick;
        }

        private void LoadExhibitions()
        {
            using (var context = new ProjectContext())
            {
                exhibitions = context.Database.SqlQuery<Exhibition>("SELECT * FROM Exhibitions").ToList();
            }

            Console.WriteLine($"Загружено {exhibitions.Count} выставок.");

            List<PictureBox> pictureBoxes = new List<PictureBox> { pictureBox, pictureBox2, pictureBox3 };
            pictureBoxToExhibitionMap.Clear();

            for (int i = 0; i < exhibitions.Count && i < pictureBoxes.Count; i++)
            {
                var exhibition = exhibitions[i];
                var pictureBox = pictureBoxes[i];
                pictureBoxToExhibitionMap[pictureBox] = exhibition;

                Console.WriteLine($"Загрузка выставки ID: {exhibition.Id}, Название: {exhibition.AddTitle}");

                if (exhibition.CoverImage != null && exhibition.CoverImage.Length > 0)
                {
                    // Выводим размер изображения для отладки
                    Console.WriteLine($"Найдено изображение для выставки, размер: {exhibition.CoverImage.Length} байт.");

                    try
                    {
                        using (var ms = new MemoryStream(exhibition.CoverImage))
                        {
                            pictureBoxes[i].Image = Image.FromStream(ms);
                            Console.WriteLine("Изображение успешно загружено в PictureBox.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке изображения: {ex.Message}");
                    }
                }
                else
                {
                    pictureBoxes[i].Image = null;
                    Console.WriteLine("Изображение не найдено для данной выставки.");
                }
            }
        }





        private void ClearPictureBoxes()
        {
            foreach (var pb in new List<PictureBox> { pictureBox, pictureBox2, pictureBox3,
                                                 pictureBox4, pictureBox5, pictureBox6 })
            {
                pb.Image?.Dispose();
                pb.Image = null;
                pb.BorderStyle = BorderStyle.None;
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedBox &&
                pictureBoxToExhibitionMap.TryGetValue(clickedBox, out var exhibition))
            {
                selectedExhibition = exhibition;
                SelectPictureBox(clickedBox);
                btnEdit.Enabled = true;
                
            }
        }
        private void SelectPictureBox(PictureBox selectedBox)
        {
            foreach (var pb in pictureBoxToExhibitionMap.Keys)
            {
                pb.BorderStyle = pb == selectedBox ? BorderStyle.Fixed3D : BorderStyle.None;
                pb.BackColor = pb == selectedBox ? Color.LightBlue : SystemColors.Control;
            }
        }





        private void DataGridViewExhibitions_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            if (e.RowIndex >= 0 && e.RowIndex < exhibitions.Count)
            {
                var exhibition = exhibitions[e.RowIndex];
                Console.WriteLine($"Выставка выбрана: ID = {exhibition.Id}, Название = {exhibition.AddTitle}");

                if (exhibition.CoverImage != null && exhibition.CoverImage.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(exhibition.CoverImage))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                            Console.WriteLine("Изображение успешно загружено в pictureBox1.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при загрузке изображения для выставки: {ex.Message}");
                    }
                }
                else
                {
                    pictureBox.Image = null;
                    Console.WriteLine("Изображение не найдено для этой выставки.");
                }
            }
        }


        private void dataGridViewExhibitions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Exhibition selectedExhibition = exhibitions[e.RowIndex];
                using (Edit editForm = new Edit(selectedExhibition))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadExhibitions();
                        MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExhibitions();
        }

        private void btnAdd_Click_Click(object sender, EventArgs e)
        {
            Add addform = new Add();
            addform.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedExhibition != null)
            {
                var editForm = new Edit(selectedExhibition.Id, dbPath);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadExhibitions(); 
                }
            }
        }
    }
}
