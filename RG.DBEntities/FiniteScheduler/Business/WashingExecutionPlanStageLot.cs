using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingExecutionPlanStageLot
    {
        public long Id { get; set; }
        public string LotNo { get; set; }
        public int? MachineId { get; set; }
        public double? Capacity { get; set; }
        public int? CapacityUnitId { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public long? RecipeId { get; set; }
        public long? ParentLotId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Rdate { get; set; }
        public long? StageId { get; set; }
        public DateTime? ExecutionTime { get; set; }
        public byte? IsFinalized { get; set; }
        public int? FinalizedBy { get; set; }
        public DateTime? FinalizedOn { get; set; }
        public byte? Firmed { get; set; }
        public int? FirmedBy { get; set; }
        public DateTime? FirmedOn { get; set; }
    }
}
