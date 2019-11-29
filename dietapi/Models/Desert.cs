using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class Desert
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public virtual ICollection<MealDesert> MealDeserts { get; set; }
        public virtual ICollection<DailyDietLine> DailyDietLines { get; set; }
        public virtual ICollection<DailyDietLineDesert> DailyDietLineDeserts { get; set; }
    }
}
