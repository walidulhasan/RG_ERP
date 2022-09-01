using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroPlacementInstruction
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public short PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public int? DistFmTop { get; set; }
        public int? DistFmLeft { get; set; }
        public int? DistFmRight { get; set; }
        public bool? IsCentered { get; set; }
        public int? DistFmBottom { get; set; }

        public virtual EmbroSpecification Object { get; set; }
        public virtual EmbroPrintPlacementPointSetup PlacementInstruction { get; set; }
    }
}
