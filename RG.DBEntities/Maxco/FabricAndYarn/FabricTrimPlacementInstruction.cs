using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrimPlacementInstruction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricSpecificationID { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
    }
}
