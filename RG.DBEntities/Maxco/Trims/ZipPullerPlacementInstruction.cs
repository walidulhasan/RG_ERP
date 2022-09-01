using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPullerPlacementInstruction
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public short? PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public byte? UsePerPiece { get; set; }

        public virtual ZipPullerSpecification Object { get; set; }
    }
}
