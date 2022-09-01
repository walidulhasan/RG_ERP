using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class DailyTimeBuckets
    {
        [Key]
        public int DayId { get; set; }
        public DateTime DayDate { get; set; }
    }
}
