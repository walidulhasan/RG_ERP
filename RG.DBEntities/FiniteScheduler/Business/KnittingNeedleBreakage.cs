using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class KnittingNeedleBreakage
    {
        public long BreakageId { get; set; }
        public string BreakageShift { get; set; }
        public long? BreakageItemId { get; set; }
        public int? BreakageQty { get; set; }
        public DateTime? BreakageDate { get; set; }
        public long? BreakageUser { get; set; }
        public long? BreakageCompanyId { get; set; }
        public int? Machineno { get; set; }
    }
}
