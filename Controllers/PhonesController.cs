using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/Phones")]
    public class PhonesController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public PhonesController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }
        // GET api/phones
        [HttpGet]
        public JsonResult Get()
        {
           
            string json = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath +  "\\data\\path.txt");
            List<Customer> items = JsonConvert.DeserializeObject<List<Customer>>(json);


            List<string> PhoneList = new List<string>();

            List<PhoneNumber> phones = new List<PhoneNumber>();

            //List<List<PhoneNumber>> cc = items.Select(l => l.CusPhoneNumbers).ToList();
            foreach (Customer x in items)
            {
                foreach(PhoneNumber phone in x.CusPhoneNumbers)
                {
                    PhoneList.Add(phone.Number);
                }
                
            }

            return Json(PhoneList);
        }
    }
}