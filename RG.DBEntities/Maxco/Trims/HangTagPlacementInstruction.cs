using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagPlacementInstruction
    {
        public int ID { get; set; }
        [ForeignKey("HangTagSpecification")]
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }

        public virtual HangTagSpecification Object { get; set; }
    }
}
