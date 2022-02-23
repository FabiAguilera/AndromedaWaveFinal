using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    public class ProductEdit
    {
        public int TicketId { get; set; }
        public string EventName { get; set; }
        public string StatusOfTicket { get; set; }
        public decimal TicketPrice { get; set; }
        public string Admission { get; set; }
        
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Category")]
        public int VenueId { get; set; }
    }
}
