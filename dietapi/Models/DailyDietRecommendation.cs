using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDietRecommendation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DailyDiet")]
        public int DailyDietId { get; set; }
        public int Steps { get; set; }
        public double Distance { get; set; }

        public virtual DailyDiet DailyDiet { get; set; }
    }
}
