using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApiTests.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApiTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        // GET api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return this.databaseContext.Customers.ToList();


            //IList<Customer> customers = new List<Customer>();
            //for(int i = 1; i <= 10; i++)
            //{
            //    customers.Add(new Customer { Id = i, LastName = "Nom " + i, FirstName = "Prénom " + i });
            //}

            //return customers.ToArray();
        }
        
    }
}
