using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public class Merchant
    {
        [Key]
        public int MerchantId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
