using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingExecutionPlanStageProcess
    {
        public long Id { get; set; }
        public long? RecipeProcessId { get; set; }
        public long? StageId { get; set; }
    }
}
