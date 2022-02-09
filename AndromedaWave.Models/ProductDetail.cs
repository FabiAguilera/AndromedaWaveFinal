using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    
    public class ProductDetail
    {
        public int TicketId { get; set; }
        public string EventName { get; set; }
        public decimal TicketPrice { get; set; }
        public string StatusOfTicket { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public AdmissionTier Admission { get; set; }
    }
}
