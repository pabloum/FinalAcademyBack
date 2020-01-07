using LandingAgency.Api.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LandingAgency.Api.Controllers
{
    public class PackagesController : ApiController
    {
        private PackageBl packageBl = new PackageBl();

        // GET api/package
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(packageBl.GetAll());
        }

        // GET api/package?description=verylong
        [HttpGet]
        public IHttpActionResult Get(string description)
        {
            return Ok(packageBl.GetPackageByDescription(description));
        }

        // GET api/package/1
        [HttpGet]
        public IHttpActionResult GetPackageById(int id)
        {
            return Ok(packageBl.GetPackageById(id));
        }
    }
}
