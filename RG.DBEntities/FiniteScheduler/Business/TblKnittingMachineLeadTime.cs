using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingMachineLeadTime
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int FabricTypeId { get; set; }
        public int FabricQualityId { get; set; }
        public int LeadTime { get; set; }
        public double? ProductionTime { get; set; }
    }
}
