using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingMachineInstance
    {
        public CuttingMachineInstance()
        {
            CuttingMachineLoad = new HashSet<CuttingMachineLoad>();
            ResourceGroup = new HashSet<ResourceGroup>();
        }

        public int? CuttingMachineTypeId { get; set; }
        public string CuttingMachineInstanceName { get; set; }
        public int FamId { get; set; }
        public int FamparentId { get; set; }
        public int StateId { get; set; }

        public virtual CuttingMachineType Famparent { get; set; }
        public virtual ICollection<CuttingMachineLoad> CuttingMachineLoad { get; set; }
        public virtual ICollection<ResourceGroup> ResourceGroup { get; set; }
    }
}
