using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class DrawstringPlacementInstruction
    {
        public int ID { get; set; }
        [ForeignKey("DrawstringSpecification")]
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }
        public virtual DrawstringSpecification Object { get; set; }
    }
}
