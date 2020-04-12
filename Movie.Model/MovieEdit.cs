using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Model
{
    public class MovieEdit
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
    }
}
