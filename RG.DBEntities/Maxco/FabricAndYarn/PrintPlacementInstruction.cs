using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class PrintPlacementInstruction
    {
        public int ID { get; set; }
        [ForeignKey("PrintingSpecification")]
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public double? Dist_fm_Top { get; set; }
        public double? Dist_fm_Left { get; set; }
        public double? Dist_fm_Right { get; set; }
        public bool? IsCentered { get; set; }

        public virtual PrintingSpecification PrintingSpecification { get; set; }
    }
}
