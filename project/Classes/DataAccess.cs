using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class DataAccess
    {
        public void AddCategory(string name)
        {
            using (var context = new ProjectContext())
            {
                var category = new Category { Name = name };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
