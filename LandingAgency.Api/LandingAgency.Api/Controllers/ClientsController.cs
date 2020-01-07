using LandingAgency.Api.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandingAgency.Api.Controllers
{
    public class ClientsController : ApiController
    {
        // GET api/clients
        [HttpGet]
        public IHttpActionResult Get()
        {
            var clientBl = new ClientBl();

            return Ok(clientBl.GetAll());
        }
    }
}
