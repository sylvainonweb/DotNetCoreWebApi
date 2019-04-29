using System.Collections.Generic;
using System.Linq;
using DotNetCoreWebApiTests.Database;
using DotNetCoreWebApiTests.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreWebApiTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly string connectionString;

        public CustomerController(IConfiguration configuration)
        {
            this.connectionString = configuration["Data:ConnectionString"];
        }

        // GET api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            using (var context = new DatabaseContext { ConnectionString = this.connectionString })
            {
                return context.Customers.ToList();
            }            
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            using (var context = new DatabaseContext { ConnectionString = this.connectionString })
            {
                return context.Customers.Where(o => o.Id == id).FirstOrDefault();
            }
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            using (var context = new DatabaseContext { ConnectionString = this.connectionString })
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            using (var context = new DatabaseContext { ConnectionString = this.connectionString })
            {
                Customer existingCustomer = context.Customers.Where(o => o.Id == id).FirstOrDefault();
                existingCustomer.Name = customer.Name;
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.CustomerTypeId = customer.CustomerTypeId;
                context.SaveChanges();
            }
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new DatabaseContext { ConnectionString = this.connectionString })
            {
                Customer existingCustomer = context.Customers.Where(o => o.Id == id).FirstOrDefault();
                context.Remove(existingCustomer);
                context.SaveChanges();
            }
        }
    }
}
