using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class RivetPlacementInstruction
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public short? UsePerPiece { get; set; }

        public virtual RivetSpecification Object { get; set; }
    }
}
