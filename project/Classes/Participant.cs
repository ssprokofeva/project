using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 

        public int ExhibitionId { get; set; }
        public virtual Exhibition Exhibition { get; set; }
    }
}