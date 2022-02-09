using AndromedaWave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Services
{
    public class TransactionService
    {
        public bool CreateTransaction(TransactionCreate model)
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

        public TransactionDetails GetTransactionById (int Id)
        {
            using(var context = new ApplicationDbContext())
            {
                var entity =
                    context
                    .Transactions
                    .Single(e => Id == e.TransactionId);


            }
        }

    }
}
