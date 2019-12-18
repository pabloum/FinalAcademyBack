using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandingAgency.Api.Controllers
{
    public class PablosController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "Pablo", "Uribe" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "This is freaking unbelievable";
        }
    }
}
