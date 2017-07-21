using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Caching;
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
            //try
            //{
            //    var customers = _dbContext.Customers
            //        .Include(m => m.MembershipType)
            //        .Select(Mapper.Map<Customer, CustomerViewModel>)
            //        .ToList();

            //    return View(customers);
            //}
            //catch (Exception e)
            //{
            //    return View();
            //}
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _dbContext.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            return View();
        }

        //[Route("customers/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            try
            {
                var customer = _dbContext.Customers
                    .Include(m => m.MembershipType)
                    .Select(Mapper.Map<Customer, CustomerViewModel>)
                    .FirstOrDefault(i => i.Id == id);

                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //CreateAndUpdate New Customer
        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                //Customer = new CustomerViewModel(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndUpdate(CustomerFormViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var currentCustomer = _dbContext.Customers.FirstOrDefault(m => m.Id == formViewModel.Customer.Id);
                    if (currentCustomer == null)
                    {
                        currentCustomer = new Customer();
                    }
                    currentCustomer.Name = formViewModel.Customer.Name;
                    currentCustomer.MembershipTypeId = formViewModel.Customer.MembershipTypeId;
                    currentCustomer.Birthdate = formViewModel.Customer.Birthdate;
                    currentCustomer.IsSubsriberdToNewsLetter = formViewModel.Customer.IsSubsriberdToNewsLetter;
                    //_dbContext.Entry(currentCustomer).State = EntityState.Modified;

                    //}
                    //else
                    //{
                    //    var customer = new Customer();
                    //    customer.Name = formViewModel.Customer.Name;
                    //    customer.MembershipTypeId = formViewModel.Customer.MembershipTypeId;
                    //    customer.Birthdate = formViewModel.Customer.Birthdate;
                    //    customer.IsSubsriberdToNewsLetter = formViewModel.Customer.IsSubsriberdToNewsLetter;
                    //    _dbContext.Customers.Ad;
                    //}
                    _dbContext.Customers.AddOrUpdate(currentCustomer);
                    //_dbContext.Customers.AddOrUpdate(m => m.Id, new Customer
                    //{
                    //    Id = formViewModel.Customer.Id,
                    //    Name = formViewModel.Customer.Name,
                    //    MembershipTypeId = formViewModel.Customer.MembershipTypeId
                    //});
                    TempData["NewCustomerNotification"] = "Successfully!";


                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Customers");
                }
                catch (Exception e)
                {
                    TempData["NewCustomerError"] = "Something Wrong with Data Input!";
                }
            }
            var viewModel = new CustomerFormViewModel()
            {
                Customer = formViewModel.Customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}