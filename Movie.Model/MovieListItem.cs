﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Cast { get; set; }
        public enum Rating { G, PG, PG13, R }


        //public double Price { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
