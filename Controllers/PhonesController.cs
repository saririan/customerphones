using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace  CustomerContactWebAPI.Controllers
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

        //create a list of all phone numbers and display it as a jason format

        // GET api/phones
        [HttpGet]
        public JsonResult Get()
        {

            ///Reading data from  data json file and store it in a cusList
            ///
            string json = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json");
            List<Customer> cusList = JsonConvert.DeserializeObject<List<Customer>>(json);


            List<string> PhoneList = new List<string>();
         
          
            foreach (Customer tmpCustomer in cusList)
            {
                foreach(PhoneNumber phone in tmpCustomer.CusPhoneNumbers)
                {
                    PhoneList.Add(phone.Number);
                }
                
            }

            return Json(PhoneList);
        }
    }
}