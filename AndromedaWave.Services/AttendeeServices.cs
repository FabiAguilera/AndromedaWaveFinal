using AndromedaWave.Data;
using AndromedaWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class AttendeeServices
    {
        private readonly Guid _userId;

        public AttendeeServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAttendee(CreateAttendee model)
        {

            var entity =
                new Attendee()
                {
                    OwnerId = _userId,
                    AttendeeId = model.AttendeeId,
                    AttendeeName = model.AttendeeName,
                    CreatedAttendee = model.CreatedAttendee
                };
            using (var context = new ApplicationDbContext())
            {

                context.Attendees.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<AttendeeDetails> GetAttendees()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Attendees
                    .Where(e => 1 == 1)
                    .Select(e =>
                    new AttendeeDetails()
                    {
                        AttendeeId = e.AttendeeId,
                        CreatedAttendee = e.CreatedAttendee,
                        AttendeeName = e.AttendeeName
                    });
                return query.ToArray();
            }

        }
        public AttendeeDetails GetAttendeeById(int AttendeeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Attendees
                    .SingleOrDefault(e => AttendeeId == e.AttendeeId && e.OwnerId == _userId);

                return 
                    new AttendeeDetails
                    {
                    AttendeeId = entity.AttendeeId,
                    AttendeeName = entity.AttendeeName,
                    CreatedAttendee = entity.CreatedAttendee,
                    };
            }
        }

        public bool DeleteAttendee(int AttendeeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Attendees
                    .Single(e => AttendeeId == e.AttendeeId && e.OwnerId == _userId);

                context.Attendees.Remove(entity);

                return context.SaveChanges() == 1;
            }
        }
    }
}
