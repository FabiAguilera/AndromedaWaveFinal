using AndromedaWave.Data;
using AndromedaWave.Models;
using AndromedaWave.Models.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class TransactionService
    {
        
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTransaction(CreateTransaction model)
        {
            Transaction entity =
                new Transaction()
                {
                    OwnerId = _userId,
                    IsConfirmed = model.IsConfirmed,
                    CreatedTransaction = model.CreatedTransaction,
                    ModifiedTransaction = model.ModifiedTransaction,
                    
                };
           
            using (var context = new ApplicationDbContext())
            {
                entity.Attendees = new List<Attendee>();
                entity.Merchants = new List<Merchant>();
                entity.Products = new List<Product>();
                foreach (int id in model.AttendeeId)
                {
                    var attendee = context.Attendees.Find(id);
                    entity.Attendees.Add(attendee);
                }
                foreach (int id in model.TicketId)
                {
                    var product = context.Products.Find(id);
                    entity.Products.Add(product);
                }
                foreach (int id in model.MerchantId)
                {
                    var merchant = context.Merchants.Find(id);
                    entity.Merchants.Add(merchant);
                }
               
                context.Transactions.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public TransactionDetails GetTransactionById(int Id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Transactions
                    .SingleOrDefault(e => Id == e.TransactionId && e.OwnerId == _userId );

                return 
                    new TransactionDetails 
                    {
                    TransactionId =entity.TransactionId,
                    IsConfirmed=entity.IsConfirmed,
                    CreatedTransaction=entity.CreatedTransaction,
                    ModifiedTransaction = entity.ModifiedTransaction
                    };
            }
        }
        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                         .Transactions
                         .Where(e => e.OwnerId == _userId)
                         .Select(
                             e =>
                                new TransactionListItem
                                {
                                  TransactionId = e.TransactionId,
                                  IsConfirmed = e.IsConfirmed,
                                  CreatedTransaction = e.CreatedTransaction,
                                  ModifiedTransaction= e.ModifiedTransaction  
                                });
                return query.ToArray();
            }
        }
        public bool UpdateTransaction(UpdateTransaction model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Transactions
                    .Single(e => e.TransactionId == model.TransactionId && e.OwnerId == _userId);

                entity.TransactionId = model.TransactionId;
                entity.IsConfirmed = model.IsConfirmed;
                entity.ModifiedTransaction = model.ModifiedTransaction;

                return context.SaveChanges() == 1;
            }

        }
        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                          .Transactions
                          .SingleOrDefault (e => e.TransactionId==transactionId && e.OwnerId == _userId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
