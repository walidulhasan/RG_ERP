using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingExecutionPlanStageLotBom
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public long? RecipeMaterialId { get; set; }
        public double? Quantity { get; set; }
        public int? UnitId { get; set; }
        public long? ItemId { get; set; }
        public bool? IsSubstitute { get; set; }
    }
}
