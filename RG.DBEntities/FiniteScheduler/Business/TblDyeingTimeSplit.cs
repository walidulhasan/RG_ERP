using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingTimeSplit
    {
        public int Id { get; set; }
        public long? StocktransationId { get; set; }
        public long? Rollid { get; set; }
        public double? Rollweight { get; set; }
        public int? Noofpcs { get; set; }
        public string Comment { get; set; }
    }
}
