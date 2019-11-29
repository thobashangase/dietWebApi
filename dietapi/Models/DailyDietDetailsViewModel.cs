using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDietDetailsViewModel
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int TotalCalories { get; set; }
        public DailyDietRecommendationViewModel DailyDietRecommendations { get; set; }
    }
}