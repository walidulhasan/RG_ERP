using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMachineRod
    {
        public int MachineRodId { get; set; }
        public double? MachineRodWeight { get; set; }
        public int? MachineRodMachine { get; set; }
    }
}
