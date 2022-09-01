using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WorkCenterSetup
    {
        public int WorkCenterId { get; set; }
        public string WorkCenter { get; set; }
        public short? ProcessOrder { get; set; }
        public int? CostCenterId { get; set; }
    }
}
