using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class AddDailyDietViewModel
    {
        public DateTime Day { get; set; }
        public AddDailyDietLineViewModel Breakfast { get; set; }
        public AddDailyDietLineViewModel Lunch { get; set; }
        public AddDailyDietLineViewModel Dinner { get; set; }
    }
}
