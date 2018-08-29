using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.Core.Models
{
   public  class MovieModel
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string Genre { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Price { get; set; }
    }
}
