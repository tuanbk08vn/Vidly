using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DAL;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyContext _dbContext;

        public CustomersController()
        {
            _dbContext = new VidlyContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_dbContext.Customers
                .Include(m => m.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>));
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _dbContext.Customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthdate = customerDto.Birthdate;
            //customerInDb.IsSubsriberdToNewsLetter = customerDto.IsSubsriberdToNewsLetter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

            _dbContext.SaveChanges();


        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerInDb);

            _dbContext.SaveChanges();
        }
    }
}
