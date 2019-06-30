using System.Collections.Generic;
using VideoProject.Models;

namespace VideoProject.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }

    }
}