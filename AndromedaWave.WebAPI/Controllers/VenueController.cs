using AndromedaWave.Models.VenueModels;
using AndromedaWave.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndromedaWave.WebAPI.Controllers
{
    [Authorize]
    public class VenueController : ApiController
    {
        private VenueService CreateVenueService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            VenueService venueService = new VenueService(userId);
            return venueService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            VenueService venueService = CreateVenueService();
            var venues = venueService.GetVenues();
            return Ok(venues);
        }

        [HttpPost]
        public IHttpActionResult Post(VenueCreate venue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateVenueService();
            if (!service.CreateVenue(venue))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVenueService();
            if (!service.DeleteVenue(id))
                return InternalServerError();
            return Ok();
        }
    }
}
