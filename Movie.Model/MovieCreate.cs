using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Model
{
    public class MovieCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(8000)]
        public string Description { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Genre { get; set; }

        //[Required]
        //[MaxLength(8000)]
        //public string Description { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Cast { get; set; }

        //[Required]
        //public Nullable<System.DateTime> MovieTime { get; set; }


    }
}
