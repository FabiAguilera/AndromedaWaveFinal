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
                    MerchantId = model.MerchantId,
                    CategoryId = model.CategoryId,
                    VenueId = model.VenueId
                };

            using (var ctx = new ApplicationDbContext())   
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
                                CreatedUtc = e.CreatedUtc,
                                MerchantId = e.MerchantId,
                                CategoryId = e.CategoryId,
                                VenueId = e.VenueId
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
                        ModifiedUtc = entity.ModifiedUtc,
                        MerchantId = entity.MerchantId,
                        CategoryId = entity.CategoryId,
                        VenueId = entity.VenueId
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
                entity.MerchantId = model.MerchantId;
                entity.CategoryId = entity.CategoryId;
                entity.VenueId = entity.VenueId;

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
