using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCoreWebApiTests.Database;
using DotNetCoreWebApiTests.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreWebApiTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public DatabaseContext DatabaseContext { get; set; }

        public CustomerController(DatabaseContext DatabaseContext)
        {
            this.DatabaseContext = DatabaseContext;
        }

        // GET api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return DatabaseContext.Customers.ToList();
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return DatabaseContext.Customers.Where(o => o.Id == id).FirstOrDefault();
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            DatabaseContext.Customers.Add(customer);
            DatabaseContext.SaveChanges();
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            Customer existingCustomer = DatabaseContext.Customers.Where(o => o.Id == id).FirstOrDefault();
            existingCustomer.Name = customer.Name;
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.CustomerTypeId = customer.CustomerTypeId;
            DatabaseContext.SaveChanges();
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer existingCustomer = DatabaseContext.Customers.Where(o => o.Id == id).FirstOrDefault();
            DatabaseContext.Remove(existingCustomer);
            DatabaseContext.SaveChanges();
        }
    }
}
