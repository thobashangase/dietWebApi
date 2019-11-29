using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dietapi.Models
{
    public class DailyDietLineDesert
    {
        [Key, ForeignKey("DailyDietLine")]
        public int DailyDietLineId { get; set; }
        public int DesertId { get; set; }

        public virtual DailyDietLine DailyDietLine { get; set; }
        public virtual Desert Desert { get; set; }
    }
}
