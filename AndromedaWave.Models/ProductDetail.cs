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
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public bool ProdStatus { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public ProdPriceLevel LevelPrice { get; set; }
    }
}
