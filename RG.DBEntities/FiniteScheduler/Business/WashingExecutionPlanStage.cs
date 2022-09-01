using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingExecutionPlanStage
    {
        public long Id { get; set; }
        public string StageNo { get; set; }
        public long? PlanId { get; set; }
        public long? RequisitionId { get; set; }
    }
}
