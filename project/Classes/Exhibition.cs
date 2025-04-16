using System;
using System.Collections.Generic;

namespace project
{
    public class Exhibition
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string AddTitle { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }           // Основная дата выставки
        public DateTime CreatedAt { get; set; }      // Когда добавлена в систему

        public string ImagePath { get; set; }        // Путь до изображения
        public byte[] CoverImage { get; set; }       // Обложка как бинарные данные (если надо)

        // Внешний ключ
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Связанные участники
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
