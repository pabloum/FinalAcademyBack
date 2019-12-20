using LandingAgency.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingAgency.Api.Logic
{
    public class ClientBl
    {
        public IList<ClientType> GetAll() 
        {
            using (var context = new LandingAgencyModel()) {
                return context.ClientType.ToList();
            }
        }

        public string GetClientTypeFromId(int? ClientTypeId)
        {
            // TO DO: Implementation
            return ClientType.CLIENT_COORPORATE;
        }
    }
}