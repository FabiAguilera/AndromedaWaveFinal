using AndromedaWave.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class CreateTransaction
    {
        
        [Required]
        public bool IsConfirmed { get; set; }
        
        public DateTimeOffset CreatedTransaction { get; set; } = DateTimeOffset.Now;
      
        public DateTimeOffset ModifiedTransaction { get; set; }

        [Required]
        public ICollection<int> AttendeeId { get; set; }
        [Required]
        public ICollection<int> TicketId { get; set; }
        [Required]
        public ICollection<int> MerchantId { get; set; }
    }
}
