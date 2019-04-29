using DotNetCoreWebApiTests.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebApiTests.Client
{
    class Program
    {


        static void Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            {
                //await GetCustomers();
                //await AddCustomer();
                await GetCustomers();
                await UpdateCustomer();
                await GetCustomers();
                await DeleteCustomer();
                await GetCustomers();

            }).GetAwaiter().GetResult();

            Console.WriteLine("Veuillez presser une touche pour arrêter la console");
            Console.ReadLine();
        }

        private static async Task AddCustomer()
        {
            Console.WriteLine("AddCustomer()");

            Customer customer = new Customer();
            customer.Name = Guid.NewGuid().ToString();
            customer.FirstName = Guid.NewGuid().ToString();
            customer.CustomerTypeId = (int)CustomerTypeEnumeration.Particulier;
            await CustomerServiceClient.AddCustomer(customer);
        }

        private static async Task UpdateCustomer()
        {
            Console.WriteLine("UpdateCustomer()");

            int id = 1;
            Customer customer = await CustomerServiceClient.GetCustomer(id);
            customer.Name = "BLANCHARD";
            customer.FirstName = "SYLVAIN";
            if (customer.CustomerTypeId == (int)CustomerTypeEnumeration.Particulier)
            {
                customer.CustomerTypeId = (int)CustomerTypeEnumeration.Professionnel;
            }
            else
            {
                customer.CustomerTypeId = (int)CustomerTypeEnumeration.Particulier;
            }
            await CustomerServiceClient.UpdateCustomer(customer);
        }

        private static async Task DeleteCustomer()
        {
            Console.WriteLine("DeleteCustomer()");

            int id = 2014;
            await CustomerServiceClient.DeleteCustomer(id);
        }

        private static async Task GetCustomers()
        {
            Console.WriteLine("GetCustomers()");

            List<Customer> customers = await CustomerServiceClient.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} : {customer.Name} {customer.FirstName} => {(CustomerTypeEnumeration)customer.CustomerTypeId}");
            }
            Console.WriteLine();
        }
    }
}
