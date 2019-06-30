using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using VideoProject.Models;
using VideoProject.ViewModel;
using VideoProject.ViewModels;

namespace VideoProject.Controllers
{
    public class CustomersController : Controller
    {
        public static List<Customer> customerList = new List<Customer>()
            {
                new Customer() {Id = 0, Name = "John Smith"},
                new Customer() {Id = 1, Name="Mary Williams"}
            };
        public static Movie movie = new Movie() { Id = 0, Name = "Shrek" };

        RandomMovieViewModel randomMovie = new RandomMovieViewModel() { Movie = movie, Customers = customerList };

        // GET: Customers
        public ActionResult Index()
        {
            return View(randomMovie);
        }

        public ActionResult Details(int id)
        {

            if (id < randomMovie.Customers.Count)
            {
                var customer = randomMovie.Customers[id];
                return View(customer);
            }
            return View("NoCustomer");
        }
    }
}
