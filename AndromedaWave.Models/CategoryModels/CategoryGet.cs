using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaWave.Models.CategoryModels
{
    public class CategoryGet
    {
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category Type")]
        public string CategoryType { get; set; }
        public override string ToString() => CategoryType;
    }
}
