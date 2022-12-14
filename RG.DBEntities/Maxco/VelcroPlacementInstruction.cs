using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VelcroPlacementInstruction
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }

        public virtual VelcroSpecification Object { get; set; }
    }
}
