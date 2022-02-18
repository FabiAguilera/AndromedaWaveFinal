using AndromedaWave.Data;
using AndromedaWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class MerchantService
    {
        private readonly Guid _userId;

        public MerchantService(Guid userId) 
        {
            _userId = userId;
        }

        public bool CreateMerchant(MerchantCreate model)
        {
            var entity =
                new Merchant()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Address = model.Address,
                    CreatedUtc = DateTimeOffset.Now,
                };

            using (var ctx = new ApplicationDbContext())    
            {
                ctx.Merchants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MerchantListItem> GetMerchants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Merchants
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new MerchantListItem
                            {
                                MerchantId = e.MerchantId,
                                Name = e.Name,
                                Address = e.Address,
                                CreatedUtc = e.CreatedUtc
                            }
                            );
                return query.ToArray();
            }
        }

        public MerchantDetail GetMerchantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Merchants
                    .Single(e => e.MerchantId == id && e.OwnerId == _userId);
                return
                    new MerchantDetail
                    {
                        MerchantId = entity.MerchantId,
                        Name = entity.Name,
                        Address = entity.Address,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateMerchant(MerchantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Merchants
                    .Single(e => e.MerchantId == model.MerchantId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMerchant(int merchantId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Merchants
                    .Single(e => e.MerchantId == merchantId && e.OwnerId == _userId);
                ctx.Merchants.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
