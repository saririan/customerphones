using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Hosting;

namespace  CustomerContactWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public CustomersController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }


        //showing list of all customers and their phone numbers
        // GET api/customer
        [HttpGet]
        public JsonResult Get()
        {
            var text = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json");
            var customers = JsonConvert.DeserializeObject(text);

            return Json(customers);
        }

        
        //Find a customer by name and showing related phone numbers
        // GET api/customer/byname/{name}
        [HttpGet("byname/{customername}")]
        public ActionResult Get(string customername)
        {

            string json = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json");
            List<Customer> cusList = JsonConvert.DeserializeObject<List<Customer>>(json);

            //search cusList(customer list) matching for customername
            var foundCustomer = cusList.Find( x => x.Name == customername);
            if (foundCustomer != null)
            {
                return Json(foundCustomer.CusPhoneNumbers);
            }
            else return NotFound();
        }


        //use a post method to create some test customers and numbers and write to a json file
        // POST api/customer/
        [HttpPost]
        public void Post()
        {
            List<Customer> customers = new List<Customer>();
                 
            customers.Add(new Customer("paul", new List<PhoneNumber> { new PhoneNumber("11111", false), new PhoneNumber("22222", false) }));
            customers.Add(new Customer("pitter", new PhoneNumber("33333", false)));
            customers.Add(new Customer("johne", new List<PhoneNumber> { new PhoneNumber("44444", false), new PhoneNumber("55555", false) }));
            customers.Add(new Customer("sam", new PhoneNumber("66666", false)));
            string json = JsonConvert.SerializeObject(customers.ToArray());


            //write string to a jason file
            System.IO.File.WriteAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json", json);

        }

       
    }
}