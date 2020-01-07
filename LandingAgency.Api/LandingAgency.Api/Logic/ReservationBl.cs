using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class ReservationBl
    {
        public IList<Reservation> GetAll()
        {
            using (var context = new LandingAgencyModel())
            {
                return context.Reservation.ToList();
            }
        }

        public Reservation GetReservationById(int id)
        {
            using (var context = new LandingAgencyModel())
            {
                return context.Reservation.First(c => c.ReservationId == 1);
            }
        }
    }
}