using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    

    public class ProductListItem
    {
        public int TicketId { get; set; }
<<<<<<< HEAD
        
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        
        [Display(Name = "Availability")]
        public string StatusOfTicket { get; set; }
        
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }
        
        [Display(Name = "Admission Tier")]
=======
        public string EventName { get; set; }
        public string StatusOfTicket { get; set; }
        public decimal TicketPrice { get; set; }
>>>>>>> 3eaffbfd53eaf97757e1d0a9b8d912688e460c61
        public AdmissionTier Admission { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
    }
}
