using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {

            if (id < _context.Customers.ToList().Count)
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
                return View(customer);
            }
            return View("NoCustomer");
        }
    }
}
