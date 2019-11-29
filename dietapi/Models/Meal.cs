using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MealTypeId { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }

        public virtual MealType MealType { get; set; }
        public virtual ICollection<MealDesert> MealDeserts { get; set; }
    }
}
