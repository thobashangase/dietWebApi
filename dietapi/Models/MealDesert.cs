using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class MealDesert
    {
        [Key, ForeignKey("Meal")]
        public int MealId { get; set; }
        [Key, ForeignKey("Desert")]
        public int DesertId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Desert Desert { get; set; }
    }
}
