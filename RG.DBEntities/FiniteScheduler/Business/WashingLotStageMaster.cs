using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotStageMaster
    {
        public long Id { get; set; }
        public string StageNo { get; set; }
        public long? LotMasterId { get; set; }
        public int? MachineId { get; set; }
        public double? Capacity { get; set; }
        public int? CapacityUnitId { get; set; }
        public DateTime? Rdate { get; set; }
        public byte? IsFinalized { get; set; }
    }
}
