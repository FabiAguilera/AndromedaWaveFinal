using AndromedaWave.Data;
using AndromedaWave.Models.VenueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class VenueService
    {
        public VenueService() { }

        private readonly Guid _authorId;

        public VenueService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateVenue(VenueCreate model)
        {
            Venue entity =
                new Venue()
                {
                    AuthorId = _authorId,
                    VenueName = model.VenueName,
                    VenueAddress = model.VenueAddress,
                    VenueDescription = model.VenueDescription,
                };
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VenueGet> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Venues
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new VenueGet()
                        {
                            VenueId = e.VenueId,
                            VenueName = e.VenueName,
                            VenueAddress = e.VenueAddress,
                        });
                return query.ToArray();
            }
        }

        public bool DeleteVenue(int venueId)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Venue Entity =
                    ctx
                    .Venues
                    .Single(e => e.VenueId == venueId && e.AuthorId == _authorId);

                ctx.Venues.Remove(Entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
