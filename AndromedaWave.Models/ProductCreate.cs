using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public enum ProdPriceLevel
    {
        GeneralAdmission = 1,
        ClubMembers,
        VIP
    }

    public class ProductCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character!")]
        public string ProdName { get; set; }
        
        [Required]
        public decimal ProdPrice { get; set; }

        [Required]
        public ProdPriceLevel LevelPrice { get; set; }

        [Required]
        public bool ProdStatus { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
