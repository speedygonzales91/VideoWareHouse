﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using VideoProject.DTOs;
using VideoProject.Models;

namespace VideoProject.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // get/api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.
                Include(c => c.MembershipType).
                ToList().
                Select(Mapper.Map<Customer, CustomerDTO>);

        }

        // get/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        // post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);


            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDTO);
        }

        // put /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDb);

            _context.SaveChanges();
        }


        // delete /api/customers/1
        [HttpDelete]
        public void DeleteCustomer (int id)
        {
            var custommerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (custommerToDelete == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(custommerToDelete);

            _context.SaveChanges();
        }


    }
}
