using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public Movie movie { get; set; }
    }
}