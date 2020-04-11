using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class Movie
    {   
        [Key]
        public int MovieId { get; set; }
        
        [Required]
        public string MovieImage { get; set; }
        
        [Required]
        public string MovieName { get; set; }
        
        [Required]
        public string MovieGrenre { get; set; }
        
        [Required]
        public string MovieDescription { get; set; }
        
        [Required]
        public string MovieRating { get; set; }
        
        [Required]
        public Nullable<System.DateTime> MovieTime { get; set; }
        
        [Required]
        public string MovieCast { get; set; }
    }
}
