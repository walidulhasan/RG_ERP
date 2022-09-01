using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SpreadingLeadTime
    {
        public int SpreadingTimeId { get; set; }
        public int? SpreadingMachineTypeId { get; set; }
        public int? FabricTypeId { get; set; }
        public double? SpreadingTime { get; set; }
        public double? MachineReturnTime { get; set; }
        public double? LayerCutTime { get; set; }
        public double? AdjustMentTime { get; set; }

        public virtual SpreaderMachineType SpreadingMachineType { get; set; }
    }
}
