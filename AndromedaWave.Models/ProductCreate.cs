using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class ProductCreate
    {
        [Required]
<<<<<<< HEAD
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        
        [Required]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Display(Name = "Admission Tier")]
        public AdmissionTier Admission { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public string StatusOfTicket { get; set; }

        [Required]
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
=======
        public string EventName { get; set; }
        
        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public AdmissionTier Admission { get; set; }

        [Required]
        public string StatusOfTicket { get; set; }
>>>>>>> 3eaffbfd53eaf97757e1d0a9b8d912688e460c61
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
