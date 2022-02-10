using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class DeleteAttendee
    {
        [Key]
        [Required]
        public int AttendeeId { get; set; }
        [Required]
        public string AttendeeName { get; set; }
        [Required]
        public DateTime CreatedAttendee { get; set; }

    }
}
