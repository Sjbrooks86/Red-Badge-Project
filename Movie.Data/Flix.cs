using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class Flix
    {   

        [Key]
        public int MovieId { get; set; }

        public Guid OwnerId { get; set; }

        public string MovieImage { get; set; }
        
        public string MovieName { get; set; }
        
        public string MovieGenre { get; set; }
        
        public string MovieDescription { get; set; }
        
        public enum Rating { G, PG, PG13, R }
        
        public Rating MovieRating { get; set; }
        
        //[Required]
        //public Nullable<System.DateTime> MovieTime { get; set; }
        
        public string MovieCast { get; set; }
        //public double Price { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
