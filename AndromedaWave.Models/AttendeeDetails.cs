using AndromedaWave.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class AttendeeDetails
    {

        public string AttendeeName { get; set; }

        public Guid OwnerId { get; set; }

        public int AttendeeId { get; set; }

        public DateTimeOffset CreatedAttendee { get; set; }
        public DateTimeOffset? ModifiedAttendee { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
