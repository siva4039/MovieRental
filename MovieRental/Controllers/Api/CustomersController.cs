using AutoMapper;
using MovieRental.Dtos;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;



namespace MovieRental.Controllers.Api
{
    public class CustomersController : ApiController
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
        //Get api/customers
        [HttpGet]
        public IHttpActionResult GetCustomer(string query = null)
        {
            var customersQuery = _context.customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDto =customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDto);
        }
        //Get api/customers/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok( Mapper.Map<Customer,CustomerDto>(customer));
        }
        //Post api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        //PUT api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cusInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if(cusInDb == null)
            {
                return NotFound();
            }
            Mapper.Map(customerDto, cusInDb);

            _context.SaveChanges();
            return Ok();
        }
        //Delete api/customer/1
        [HttpDelete]
        public IHttpActionResult Delete (int id)
        {
            var cusInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if (cusInDb == null)
            {
                return NotFound();
            }
            _context.customers.Remove(cusInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}
