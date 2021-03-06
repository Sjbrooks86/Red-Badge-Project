﻿using Movie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Movie.Data.Flix;
using static Movie.Model.MovieCreate;

namespace Movie.Model
{
    public class MovieEdit
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Rating MovieRating { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
    }
}
