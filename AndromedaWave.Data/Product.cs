﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public enum AdmissionTier
    {
        GeneralAdmission,
        ClubMembers,
        VIP
    }
    public class Product
    {
        [Key, Column("TicketId")]
        public int TicketId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string EventName { get; set; }
        
        [Required]
        public decimal TicketPrice { get; set; }
        
        [Required]
        public AdmissionTier Admission { get; set; }
        
        [Required]
        public string StatusOfTicket { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
       
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}