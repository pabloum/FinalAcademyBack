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
    public class ComissionController : ApiController
    {
        // GET api/comission
        [HttpGet]
        public IHttpActionResult Get()
        {
            var reservationBl = new PackageBl();

            return Ok(reservationBl.GetAll());
        }

        // POST api/comission
        [HttpPost]
        public IHttpActionResult Post([FromBody] Reservation reservation)
        {
            ComissionBl comissionBl = new ComissionBl();
            decimal commision = comissionBl.GetComission(reservation);

            return Ok(commision);
        }
    }
}
