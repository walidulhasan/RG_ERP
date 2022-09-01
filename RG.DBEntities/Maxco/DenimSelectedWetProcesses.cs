using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.Setup;

namespace RG.DBEntities.Maxco
{
    public partial class DenimSelectedWetProcesses
    {
        public int Id { get; set; }
        public int ProcessTypeId { get; set; }
        public int ProcessStageId { get; set; }
        public bool? IsStitch { get; set; }
        public int WetProcessMainId { get; set; }
        public string PantoneNo { get; set; }

        public virtual WetProcessStagesSetup ProcessStage { get; set; }
    }
}
