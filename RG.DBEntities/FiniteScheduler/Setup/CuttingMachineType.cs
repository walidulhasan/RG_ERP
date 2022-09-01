using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class CuttingMachineType
    {
        public CuttingMachineType()
        {
            CuttingMachineInstance = new HashSet<CuttingMachineInstance>();
            MachineOperation = new HashSet<MachineOperation>();
            RangeCalculation = new HashSet<RangeCalculation>();
        }

        public string CuttingMachineTypeName { get; set; }
        public int FamId { get; set; }
        public int FamparentId { get; set; }

        public virtual ICollection<CuttingMachineInstance> CuttingMachineInstance { get; set; }
        public virtual ICollection<MachineOperation> MachineOperation { get; set; }
        public virtual ICollection<RangeCalculation> RangeCalculation { get; set; }
    }
}
