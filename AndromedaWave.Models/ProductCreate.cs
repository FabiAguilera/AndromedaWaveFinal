﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models
{
    public class ProductCreate
    {
        [Required]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        
        [Required]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Display(Name = "Admission Tier")]
        public AdmissionTier Admission { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public string StatusOfTicket { get; set; }

        [Required]
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
