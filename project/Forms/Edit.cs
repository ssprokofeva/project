using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly ProjectContext _db = new ProjectContext();
        private byte[] _coverImageBytes;
        private string _selectedFolderPath;
        private int selectedExhibitionId;
        public Edit()
        {
            InitializeComponent();

            // Настройка элементов формы
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        public Edit(Exhibition selectedExhibition)
        {
            InitializeComponent();

            // Заполняем форму данными выставки
            txtTitle.Text = selectedExhibition.AddTitle;
            dateTimePicker1.Value = selectedExhibition.Date;

            // Загружаем изображение в pictureBox (если есть)
            if (selectedExhibition.CoverImage != null)
            {
                using (var ms = new System.IO.MemoryStream(selectedExhibition.CoverImage))
                {
                    pictureBoxCover.Image = Image.FromStream(ms);
                }
            }

            // Сохраняем ID для использования в методе сохранения
            selectedExhibitionId = selectedExhibition.Id;
        }

        // Кнопка выбора обложки
        private void btnSelectCover_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxCover.Image = Image.FromFile(openFileDialog.FileName);
                    _coverImageBytes = File.ReadAllBytes(openFileDialog.FileName);  // Сохраняем изображение в массив байтов
                }
            }
        }


        // Кнопка сохранения
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название выставки");
                return;
            }

            try
            {
                var exhibition = _db.Exhibitions.Find(selectedExhibitionId);  // Используем переменную ID
                if (exhibition != null)
                {
                    exhibition.AddTitle = txtTitle.Text;
                    exhibition.Date = dateTimePicker1.Value;

                    if (_coverImageBytes != null)
                    {
                        exhibition.CoverImage = _coverImageBytes;  // Обновляем изображение
                    }

                    _db.SaveChanges();

                    MessageBox.Show("Выставка успешно обновлена!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }



        private void btnChange_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Затем выбираем папку
                    using (var folderDialog = new FolderBrowserDialog())
                    {
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            _coverImageBytes = File.ReadAllBytes(fileDialog.FileName);
                            _selectedFolderPath = folderDialog.SelectedPath;
                            pictureBoxCover.Image = Image.FromFile(fileDialog.FileName);
                        }
                    }
                }
            }
        }
    }
}
         
  




