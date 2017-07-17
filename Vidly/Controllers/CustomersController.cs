using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _dbContext;

        public CustomersController()
        {
            _dbContext = new VidlyContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _dbContext.Dispose();
        //}
        // GET: Customers
        //[Route("customers")]
        public ActionResult Index()
        {
            var customers = _dbContext.Customers
                .Include(m => m.MembershipType)
                .Select(Mapper.Map<Customer, CustomerViewModel>)
                .ToList();

            return View(customers);
        }

        //[Route("customers/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return Content("Customer cannot be found. Please back to home!");
            try
            {
                var customer = _dbContext.Customers
                    .Include(m => m.MembershipType)
                    .Select(Mapper.Map<Customer, CustomerViewModel>)
                    .FirstOrDefault(i => i.Id == id);
                return View(customer);
            }
            catch (Exception e)
            {
                return View();

            }
        }
    }
}