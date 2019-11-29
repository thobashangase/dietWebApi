using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDietLine
    {
        public int Id { get; set; }
        public int DailyDietId { get; set; }
        public int MealId { get; set; }
        public int DesertId { get; set; }

        public virtual DailyDiet DailyDiet { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Desert Desert { get; set; }
        public virtual ICollection<DailyDietLineDesert> DailyDietLineDeserts { get; set; }
    }
}
