using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models.TransactionModels
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }
        public bool IsConfirmed { get; set; }

        public DateTimeOffset CreatedTransaction { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedTransaction { get; set; }
    }
}
