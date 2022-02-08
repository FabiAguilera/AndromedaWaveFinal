using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class ProductListItem
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public bool ProdStatus { get; set; }
        public decimal ProdPrice { get; set; }
        public ProdPriceLevel LevelPrice { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
