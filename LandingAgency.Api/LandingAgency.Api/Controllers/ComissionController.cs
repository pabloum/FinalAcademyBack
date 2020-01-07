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
            var reservation = new Reservation();
            var comissionBl = new ComissionBl();

            return Ok(comissionBl.GetComission(reservation));
        }

        // POST api/comission
        [HttpPost]
        public void Post([FromBody] Reservation res)
        {
            LandingAgencyModel LAM = new LandingAgencyModel();
            Reservation reservation = new Reservation();

            reservation.DurationStay = res.DurationStay;
            reservation.AmountTravelers = res.AmountTravelers;
            reservation.Package = res.Package;
            reservation.Client = res.Client;

            LAM.Reservation.Add(reservation);
            LAM.SaveChanges();
        }
    }
}
