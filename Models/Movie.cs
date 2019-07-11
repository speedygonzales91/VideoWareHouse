using System;
using System.ComponentModel.DataAnnotations;

namespace VideoProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Released")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date of Addition")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}