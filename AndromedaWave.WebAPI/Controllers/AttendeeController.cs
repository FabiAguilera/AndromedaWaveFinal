
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AndromedaWave.Models;
using AndromedaWave.Services;
using Microsoft.AspNet.Identity;

namespace AndromedaWave.WebAPI.Controllers
{
    [Authorize]
    public class AttendeeController : ApiController
    {
        private AttendeeServices CreateAttendeeServices()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttendeeServices(userId);
            return service;
        }

        [HttpPost]
        public IHttpActionResult CreateAttendee(CreateAttendee model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAttendeeServices();

            if (!service.CreateAttendee(model))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAttendeeById(int AttendeeId)
        {
            var service = CreateAttendeeServices();

            if (service.GetAttendeeById(AttendeeId) == null)
                return BadRequest("We couldn't find this Id");

            var attendee = service.GetAttendeeById(AttendeeId);

            return Ok(attendee);
        }

        [HttpGet]
        public IHttpActionResult GetAllAttendees()
        {
            AttendeeServices attendeeServices = CreateAttendeeServices();

            var attendees = attendeeServices.GetAttendees();

            return Ok(attendees);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendee(int Id)
        {
            var service = CreateAttendeeServices();

            if (!service.DeleteAttendee(Id))
                return InternalServerError();

            return Ok("Attendee has been deleted!");
        }
    }
}
