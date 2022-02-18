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
        [Required]
        public DateTimeOffset CreatedTransaction { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset ModifiedTransaction { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}
