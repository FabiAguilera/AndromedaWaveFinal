using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public enum ProdPriceLevel
    {
        GeneralAdmission = 1,
        ClubMembers,
        VIP
    }
    public class Product
    {
        [Key]
        public int ProdId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ProdName { get; set; }
        
        [Required]
        public decimal ProdPrice { get; set; }
        
        [Required]
        public ProdPriceLevel LevelPrice { get; set; }
        
        [Required]
        public bool ProdStatus { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
       
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
