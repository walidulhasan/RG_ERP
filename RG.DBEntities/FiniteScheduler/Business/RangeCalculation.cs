using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class RangeCalculation
    {
        public int RangeSetupId { get; set; }
        public int CuttingMachineFamId { get; set; }
        public int Gsm { get; set; }
        public int FabricTypeId { get; set; }
        public int Layer { get; set; }

        public virtual CuttingMachineType CuttingMachineFam { get; set; }
    }
}
