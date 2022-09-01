using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GwmachineOperationMachineType
    {
        public long Id { get; set; }
        public long GwmachineTypeId { get; set; }
        public long GwmachineOperationId { get; set; }
        public double CycleTime { get; set; }
        public double Capacity { get; set; }
    }
}
