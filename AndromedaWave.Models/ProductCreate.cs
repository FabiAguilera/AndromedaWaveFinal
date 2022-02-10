using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public enum AdmissionTier
    {
        GeneralAdmission = 1,
        ClubMembers,
        VIP
    }

    public class ProductCreate
    {
        [Required]
        public string EventName { get; set; }
        
        [Required]
        public decimal TicketPrice { get; set; }

        [Required]
        public AdmissionTier Admission { get; set; }

        [Required]
        public string StatusOfTicket { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
