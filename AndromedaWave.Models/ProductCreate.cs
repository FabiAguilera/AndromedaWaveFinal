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
        [MinLength(1, ErrorMessage = "Please enter at least 1 character!")]
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
