using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public class PatternPieceSpecification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricSpecificationID { get; set; }
        public int PatternPieceID { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
    }
}
