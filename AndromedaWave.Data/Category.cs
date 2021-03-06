using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string CategoryType { get; set; }
        
        public Guid AuthorId { get; set; }

        public virtual ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
