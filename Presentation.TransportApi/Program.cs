using Newtonsoft.Json;
using Shop.Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.TransportApi
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static Program()
        {
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        static void Main(string[] args)
        {
            Get();
            Post();
            Console.ReadLine();
        }
        async static Task Get()
        {
            var responseString = await client.GetStringAsync("http://localhost:56332/api/Deliveryapi");
           
            var delivery = JsonConvert.DeserializeObject<GetDeliveryDto>(responseString);
            Console.WriteLine(string.Format("{0} {1} {2} {3}", delivery.Id,delivery.CustomerEmail, delivery.AddressFromId,delivery.AddressToId));
        }
        async static Task Post()
        {
            Address from = new Address()
            {
                Country = "Polska",
                City = "Wrocław",
                Street = "MArszałkowska",
                Number = 123
            };
            Address to = new Address()
            {
                Country = "Polska",
                City = "Frodziszow mazowiecki",
                Street = "Główna",
                Number = 88
            };
            var delivery = new AddDeliveryDto()
            {
                AddressFrom = from,
                AddressTo = to,
                PaymentStatus = "not paid"
            };
            var request = JsonConvert.SerializeObject(delivery);
            StringContent content = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:56332/api/Deliveryapi", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
        }
    }
    public class GetDeliveryDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public int AddressFromId { get; set; }
        public int AddressToId { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime? CreateTime { get; set; }
    }
    public class AddDeliveryDto
    {
        public string PaymentStatus { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
    }
}
