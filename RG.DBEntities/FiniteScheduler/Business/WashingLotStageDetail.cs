using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotStageDetail
    {
        public long Id { get; set; }
        public long? StageId { get; set; }
        public int? RecipeProcessId { get; set; }
        public double? Quantity { get; set; }
    }
}
