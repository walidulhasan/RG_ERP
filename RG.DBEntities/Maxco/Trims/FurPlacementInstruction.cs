using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class FurPlacementInstruction
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public int PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }

        public virtual FurSpecification Object { get; set; }
    }
}
