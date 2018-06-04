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
    [Route("api/Activate")]
    public class ActivateController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;

        public ActivateController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        /// <summary>
        /// Activate a phone number
        /// </summary>
        /// <param name="phonenumber">customer phone number</param>

        // GET api/Activate/PhoneNumber
        [HttpGet("{phonenumber}")]
        public void Get( string phonenumber)
        {

            ///Reading data from  data json file and store it in a cusList

            string Rjson = System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json");
            List<Customer> cusList = JsonConvert.DeserializeObject<List<Customer>>(Rjson);



            //navigate customer list and set active=true if found desier phone number

            foreach (Customer tmpCustomer in cusList)
            {
                foreach (PhoneNumber phone in tmpCustomer.CusPhoneNumbers)
                {
                    if (phone.Number == phonenumber)
                    {
                        phone.Active = true;
                    }
                }

            }

            string Wjson = JsonConvert.SerializeObject(cusList.ToArray());

            //write string to  jason file
            System.IO.File.WriteAllText(_hostingEnvironment.ContentRootPath + @"\data\data.json", Wjson);

        }
    }
}