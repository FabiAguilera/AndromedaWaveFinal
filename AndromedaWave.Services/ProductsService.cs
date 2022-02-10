using AndromedaWave.Data;
using AndromedaWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class ProductsService
    {
        private readonly Guid _userId; // private field

        public ProductsService(Guid userId) // constructor
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    EventName = model.EventName,
                    StatusOfTicket = model.StatusOfTicket,
                    Admission = (Data.AdmissionTier)model.Admission,
                    TicketPrice = model.TicketPrice,
                    CreatedUtc = DateTimeOffset.Now,
                    //CategoryId = model.CategoryId
                };

            using (var ctx = new ApplicationDbContext())    // allows us to close the connection to the database right here
            // when the DbContext is connected and we will be using it for something
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ProductListItem
                            {
                                TicketId = e.TicketId,
                                TicketPrice = e.TicketPrice,
                                EventName = e.EventName,
                                Admission = (Models.AdmissionTier)e.Admission,
                                StatusOfTicket = e.StatusOfTicket,
                                CreatedUtc = e.CreatedUtc
                            }
                            );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.TicketId == id && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        TicketId = entity.TicketId,
                        StatusOfTicket = entity.StatusOfTicket,
                        EventName = entity.EventName,
                        TicketPrice = entity.TicketPrice,
                        Admission = (Models.AdmissionTier)entity.Admission,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.TicketId == model.TicketId && e.OwnerId == _userId);

                entity.EventName = model.EventName;
                entity.TicketPrice = model.TicketPrice;
                entity.Admission = (Data.AdmissionTier)model.Admission;
                entity.StatusOfTicket = model.StatusOfTicket;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int ticketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.TicketId == ticketId && e.OwnerId == _userId);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
