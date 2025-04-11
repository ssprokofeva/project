using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class AddExhibition
    {
        // метод для добавления я здесь пишу
        private void AddExhibition(string title, string imagePath)
        {
            using (var context = new ProjectContext())
            {
                var exhibition = new Exhibition
                {
                    Title = title,
                    ImagePath = imagePath,
                    CreatedAt = DateTime.Now
                };

                context.Exhibitions.Add(exhibition);
                context.SaveChanges();
            }
        }
    }
}
