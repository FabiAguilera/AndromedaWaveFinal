using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public class Product
    {
        [Key]
        [Required]
        public int TicketId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string EventName { get; set; }
        
        [Required]
        public decimal TicketPrice { get; set; }
        
        [Required]
        public string Admission { get; set; }
        
        [Required]
        public string StatusOfTicket { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
       
        public DateTimeOffset ModifiedUtc { get; set; }

        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
       
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
