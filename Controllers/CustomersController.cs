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

            if (id <= _context.Customers.ToList().Count)
            {
                var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
                return View(customer);
            }
            return View("NoCustomer");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var customerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(customerViewModel);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var editViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New",editViewModel);
        }
    }
}
