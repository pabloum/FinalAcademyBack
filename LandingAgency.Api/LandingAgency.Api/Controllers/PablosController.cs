﻿using LandingAgency.Api.Logic;
using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LandingAgency.Api.Controllers
{
    public class PablosController : ApiController
    {
        // GET api/pablos
        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get()
        {

            var reservationBl = new ReservationBl();

            return Ok(reservationBl.GetAll());
        }

        // POST api/pablos
        //public void Post([FromBody]string value)
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

        // PUT api/pablos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // GET api/pablos/5
        public IHttpActionResult Get(int id)
        {
            var comissionBl = new ComissionBl();
            var reservationBl = new ReservationBl();

            return Ok(comissionBl.GetComission(reservationBl.GetReservationById(id)));
        }
    }
}
