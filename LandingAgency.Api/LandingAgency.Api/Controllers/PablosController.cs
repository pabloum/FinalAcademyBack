using LandingAgency.Api.Logic;
using LandingAgency.Api.Models;
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
        // GET api/pablos
        public IHttpActionResult Get()
        {
            var clientBl = new ClientBl();
            var comissionBl = new ComissionBl();
            var reservation = new Reservation();

            // return Ok(clientBl.GetAll());
            return Ok(comissionBl.GetComission(reservation));
            // return Ok(12);
        }

        // POST api/pablos
        public void Post([FromBody]string value)
        {
        }

        // PUT api/pablos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // GET api/pablos/5
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
