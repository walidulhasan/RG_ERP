using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LacePlacementInstruction
    {
        public int ID { get; set; }
        [ForeignKey("LaceSpecification")]
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }

        public virtual LaceSpecification LaceSpecification { get; set; }
    }
}
