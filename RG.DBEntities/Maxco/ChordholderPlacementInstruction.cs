using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChordholderPlacementInstruction
    {
        public int Id { get; set; }
        public int PlacementInstructionId { get; set; }
        public int ObjectId { get; set; }
        public string OtherInstruction { get; set; }
        public byte? UsePerPiece { get; set; }

        public virtual ChordHolderSpecification Object { get; set; }
    }
}
