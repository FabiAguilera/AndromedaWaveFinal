﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class MerchantCreate
    {
        [Required]
        public int MerchantId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}