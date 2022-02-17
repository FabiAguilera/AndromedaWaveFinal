using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data.VenueEntity
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string VenueName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string VenueAddress { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string VenueDescription { get; set; }
        public Guid AuthorId { get; set; }

        //public virtual ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
