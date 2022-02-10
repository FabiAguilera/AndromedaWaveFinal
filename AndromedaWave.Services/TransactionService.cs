using AndromedaWave.Data;
using AndromedaWave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(CreateTransaction model)
        {
            var entity =
                new Transaction
                {
                    TransactionId = model.TransactionId,
                    IsConfirmed = model.IsConfirmed,
                    CreatedTransaction = model.CreatedTransaction,
                    ModifiedTransaction = model.ModifiedTransaction
                };
            using(var context = new ApplicationDbContext())
            {
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
                    .Single(e => Id == e.TransactionId);

                return new TransactionDetails
                {
                    TransactionId =entity.TransactionId,
                    IsConfirmed=entity.IsConfirmed,
                    CreatedTransaction=entity.CreatedTransaction,
                    ModifiedTransaction = entity.ModifiedTransaction
                };
            }
        }

        public bool UpdateTransaction(UpdateTransaction model)
        {
            using( var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Transactions
                    .Single(e => e.TransactionId == model.TransactionId);

                entity.TransactionId = model.TransactionId;
                entity.IsConfirmed = model.IsConfirmed;
                entity.ModifiedTransaction = model.ModifiedTransaction;
                
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Transactions
                    .Single(e => e.TransactionId==id);

                context.Transactions.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }

    }
}
