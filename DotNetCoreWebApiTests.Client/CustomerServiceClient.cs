using DotNetCoreWebApiTests.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebApiTests.Client
{
    public class CustomerServiceClient
    {
        // 5001 si le serveur est lancé via dotnet watch run
        private static string baseAddress = "https://localhost:5001/api";

        public static async Task<List<Customer>> GetCustomers()
        {
            var client = new HttpClient();
            var jsonContent = await client.GetStringAsync($"{baseAddress}/customer");
            return JsonConvert.DeserializeObject<List<Customer>>(jsonContent);
        }

        public static async Task<Customer> GetCustomer(int id)
        {
            var client = new HttpClient();
            var jsonContent = await client.GetStringAsync($"{baseAddress}/customer/{id}");
            return JsonConvert.DeserializeObject<Customer>(jsonContent);
        }

        public static async Task AddCustomer(Customer customer)
        {
            string jsonString = JsonConvert.SerializeObject(customer);

            var client = new HttpClient();
            await client.PostAsync($"{baseAddress}/customer", new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static async Task UpdateCustomer(Customer customer)
        {
            string jsonString = JsonConvert.SerializeObject(customer);

            var client = new HttpClient();
            await client.PutAsync($"{baseAddress}/customer/{customer.Id}", new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public static async Task DeleteCustomer(int id)
        {
            var client = new HttpClient();
            await client.DeleteAsync($"{baseAddress}/customer/{id}");
        }
    }
}
