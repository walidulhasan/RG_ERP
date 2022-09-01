using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class WovenSelectedWetProcesses
    {
        public WovenSelectedWetProcesses()
        {
            WovenSprayColors = new HashSet<WovenSprayColors>();
        }

        public int Id { get; set; }
        public int SelectedElementId { get; set; }
        public int ProcessTypeId { get; set; }
        public int ProcessStageId { get; set; }
        public bool? IsStitch { get; set; }

        public virtual WetProcessStagesSetup ProcessStage { get; set; }
        public virtual ICollection<WovenSprayColors> WovenSprayColors { get; set; }
    }
}
