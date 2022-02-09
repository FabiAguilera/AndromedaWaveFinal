using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
   
    public class ProductEdit
    {
        public int TicketId { get; set; }
        public string EventName { get; set; }
        public string StatusOfTicket { get; set; }
        public decimal TicketPrice { get; set; }
        public AdmissionTier Admission { get; set; }
    }
}
