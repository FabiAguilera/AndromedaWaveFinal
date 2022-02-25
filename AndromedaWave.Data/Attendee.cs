using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public class Attendee
    {
        [Key]
        public int AttendeeId { get; set; }
        
        
        public Guid OwnerId { get; set; }
        [Required]
        public string AttendeeName { get; set; }

        [Required]
        public DateTimeOffset CreatedAttendee { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ModifiedAttendee { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
