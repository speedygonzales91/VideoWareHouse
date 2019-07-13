using System;
using System.ComponentModel.DataAnnotations;

namespace VideoProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Released")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date of Addition")]
        public DateTime? DateAdded { get; set; }


        [Required]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}