using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDietSteps
    {
        [Key, ForeignKey("DailyDiet")]
        public int DailyDietId { get; set; }
        public int Count { get; set; }
        public virtual DailyDiet DailyDiet { get; set; }
    }
}
