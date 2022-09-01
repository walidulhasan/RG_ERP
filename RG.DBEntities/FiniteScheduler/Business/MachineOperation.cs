using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class MachineOperation
    {
        public int MachineOperationId { get; set; }
        public int MachineTypeId { get; set; }
        public int OperationId { get; set; }
        public int FabricTypeId { get; set; }
        public double CuttingTime { get; set; }
        public double ConstantTime { get; set; }

        public virtual CuttingMachineType MachineType { get; set; }
        public virtual CuttingOperation Operation { get; set; }
    }
}
