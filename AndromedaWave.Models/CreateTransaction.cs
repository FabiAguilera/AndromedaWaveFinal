﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class CreateTransaction
    {
        [Key]
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        [Required]
        public DateTimeOffset CreatedTransaction { get; set; } = DateTimeOffset.Now;
    }
}
