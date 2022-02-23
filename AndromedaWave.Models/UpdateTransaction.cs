using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class UpdateTransaction
    {
       
       
        [Required]
        public int TransactionId { get; set; }
        
        public bool IsConfirmed { get; set; }
        
        public DateTimeOffset ModifiedTransaction { get; set; }
    }
}
