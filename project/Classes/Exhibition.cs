using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime JubileeDate { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

