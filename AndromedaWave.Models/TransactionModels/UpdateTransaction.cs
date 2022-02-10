﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class UpdateTransaction
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int TransactionId { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        [Required]
        public DateTimeOffset ModifiedTransaction { get; set; }
    }
}