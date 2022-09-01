using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonPlacementInstruction
    {
      
       [Key]
        public int ID { get; set; }
        [ForeignKey("ButtonSpecification")]
        public long ObjectID { get; set; }
        public int? PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public int? UsePerPiece { get; set; }

        public virtual ButtonSpecification ButtonSpecification { get; set; }
    }
}
