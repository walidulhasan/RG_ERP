using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BeadPlacementInstruction
    {
        [Key]
        public int ID { get; set; }
        public long ObjectID { get; set; }
        public int? PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public short? UsePerPiece { get; set; }

        public virtual BeadSpecification BeadSpecification { get; set; }
    }
}
