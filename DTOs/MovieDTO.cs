using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoProject.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime? DateAdded { get; set; }


        [Required]
        [Range(1, 20,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public byte NumberInStock { get; set; }


        [Required]
        public int GenreId { get; set; }
    }
}