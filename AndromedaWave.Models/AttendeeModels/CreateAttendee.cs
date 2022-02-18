using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class CreateAttendee
    {
       
        
        public int AttendeeId { get; set; }
        [Required]
        public string AttendeeName { get; set; }
        
        public DateTime CreatedAttendee { get; set; }
       
        

    }
}
