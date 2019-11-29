using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDiet
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int TotalCalories { get; set; }

        public virtual ICollection<DailyDietLine> DailyDietLines { get; set; }
        public virtual ICollection<DailyDietRecommendation> DailyDietRecommendations { get; set; }
    }
}
