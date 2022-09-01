using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class NetMeshPlacementInstruction
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public short PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }

        public virtual NetMeshSpecification Object { get; set; }
    }
}
