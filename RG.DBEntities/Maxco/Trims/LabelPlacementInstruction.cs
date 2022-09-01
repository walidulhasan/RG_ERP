using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelPlacementInstruction
    {

        public int ID { get; set; }
        [ForeignKey("LabelSpecification")]
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public double? UsePerPiece { get; set; }
        public string Location { get; set; }

        public virtual LabelSpecification LabelSpecification { get; set; }
       public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
