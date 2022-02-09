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
                    ProdName = model.ProdName,
                    ProdStatus = model.ProdStatus,
                    LevelPrice = (Data.ProdPriceLevel)model.LevelPrice,
                    ProdPrice = model.ProdPrice,
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
                                ProdId = e.ProdId,
                                ProdPrice = e.ProdPrice,
                                LevelPrice = (Models.ProdPriceLevel)e.LevelPrice,
                                ProdStatus = e.ProdStatus,
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
                    .Single(e => e.ProdId == id && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProdId = entity.ProdId,
                        ProdStatus = entity.ProdStatus,
                        ProdName = entity.ProdName,
                        ProdPrice = entity.ProdPrice,
                        LevelPrice = (Models.ProdPriceLevel)entity.LevelPrice,
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
                    .Single(e => e.ProdId == model.ProdId && e.OwnerId == _userId);

                entity.ProdName = model.ProdName;
                entity.ProdPrice = model.ProdPrice;
                entity.LevelPrice = (Data.ProdPriceLevel)model.LevelPrice;
                entity.ProdStatus = model.ProdStatus;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int prodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProdId == prodId && e.OwnerId == _userId);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
