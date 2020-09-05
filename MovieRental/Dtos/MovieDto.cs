using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Should be in 1 to 20")]
        public byte NumberInStock { get; set; }
        public GenreDto Genre { get; set; }
        public byte GenreId { get; set; }
    }
}