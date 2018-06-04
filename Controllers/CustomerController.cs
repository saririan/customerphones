using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public CustomerController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        //   public static List<Customer> customers = new List<Customer>();
        // GET api/phone
        [HttpGet]
        public JsonResult Get()
        {
            var text = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + "\\data\\path.txt");
            var customers = JsonConvert.DeserializeObject(text);

            return Json(customers);
        }

        // GET api/customer/byname/{name}
        [HttpGet("byname/{customername}")]
        public ActionResult Get(string customername)
        {

            string json = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + "\\data\\path.txt");
            List<Customer> items = JsonConvert.DeserializeObject<List<Customer>>(json);

            var c = items.Find(xx => xx.Name == customername);
            if (c != null)
            {
                return Json(c.CusPhoneNumbers);
            }
            else return NotFound();
        }

        // POST api/customer/
        [HttpPost]
        public void Post()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("abc", new PhoneNumber("123", true)));
            customers.Add(new Customer("efg", new PhoneNumber("123", true)));
            customers.Add(new Customer("xyz", new PhoneNumber("123", true)));
            customers.Add(new Customer("ttt", new PhoneNumber("222", true)));
            customers.Add(new Customer("mmm", new PhoneNumber("123", true)));
            string json = JsonConvert.SerializeObject(customers.ToArray());

            //write string to file
            System.IO.File.WriteAllText(_hostingEnvironment.ContentRootPath + "\\data\\path.txt", json);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}