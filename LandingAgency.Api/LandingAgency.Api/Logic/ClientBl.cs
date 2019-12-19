using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class ClientBl
    {
        public IList<Client> GetAll() 
        {
            using (var context = new LandingAgencyModel()) {
                return context.Client.ToList();
            }
        }
    }
}