using LandingAgency.Api.Logic;
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
        public IHttpActionResult Get()
        {
            var clientBl = new ClientBl();

            return Ok(clientBl.GetAll());
        }

        // GET api/values/5
        public string Get(int id)
        {
            string message;

            if (id > 29)
            {
                message = "Number greater than 29";
            }
            else
            {
                message = "Number less than 29";
            }

            return message;
        }
    }
}
