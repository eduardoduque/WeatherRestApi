using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost/varoosapi/";

            // Create HttpCient and make a request to api/values 
            var client = new HttpClient();

            AddUser(client, baseAddress, new Person { Name = "Juan" });
            AddUser(client, baseAddress, new Person { Name = "Jose" });
            AddUser(client, baseAddress, new Person { Name = "Felix" });
            AddUser(client, baseAddress, new Person { Name = "Osa" });

            Thread.Sleep(2000);

            GetUsers(client, baseAddress);
            
            Console.ReadLine();
        }
        static void AddUser(HttpClient client, string baseAddress, Person person)
        {
            var json = new JavaScriptSerializer();

            var content = json.Serialize(person);

            var response = client.PostAsync(baseAddress + "user", new StringContent(content, Encoding.UTF8, "application/json")).Result;

            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }
        static void GetUsers(HttpClient client, string baseAddress)
        {
            var response = client.GetAsync(baseAddress + "user").Result;

            var json = new JavaScriptSerializer();
            var result = (List<Person>)json.Deserialize(response.Content.ReadAsStringAsync().Result, typeof(List<Person>));

            foreach (var item in result)
            {
                Console.WriteLine("ID: {0} Nombre: {1}", item.Id, item.Name);
            }
        }
    }
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
    }
}
