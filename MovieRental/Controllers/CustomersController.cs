using Microsoft.Ajax.Utilities;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
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

        public ActionResult Save()
        {
            var membershipType = _context.membershipTypes.ToList();
       
            var customerViewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                membershipTypes = membershipType
            };

            return View(customerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.membershipTypes.ToList()
                };

                return View("Save", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.customers.Add(customer);
            }
            else
            {
                var cusInDb = _context.customers.Single(c => c.Id == customer.Id);
                cusInDb.Name = customer.Name;
                cusInDb.BirthDate = customer.BirthDate;
                cusInDb.MembershipTypeId = customer.MembershipTypeId;
                cusInDb.IsSubscribedToNewsLetters = customer.IsSubscribedToNewsLetters;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return Content("No Employee Found");
            }
            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                membershipTypes = _context.membershipTypes.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return Content("No Employee Found");
            }
            _context.customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
      
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return Content("No customer detail found with the given id");
            }

            return View(customer);
        }

    } 
}