using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models.CategoryModels
{
    public class CategoryDelete
    {
        [Required]
        public int CategoryId { get; set; }
    }
}
