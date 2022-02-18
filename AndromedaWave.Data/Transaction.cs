using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public class Transaction
    {
        [Key]
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        [Required]
        public DateTimeOffset CreatedTransaction { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedTransaction { get; set; }
        public virtual ICollection<Attendee> Attendees { get; set;}

    }
}
