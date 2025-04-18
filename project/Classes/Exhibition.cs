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

        public DateTime Date { get; set; }            
        public DateTime CreatedAt { get; set; }       

        public string ImagePath { get; set; }         
        public byte[] CoverImage { get; set; }        
         
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
         
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
