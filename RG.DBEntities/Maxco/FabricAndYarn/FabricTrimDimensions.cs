using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTrimDimensions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("FabricSpecification")]
        public long FabricSpecificationID { get; set; }
        public double? Size { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public int? Distance { get; set; }
        public int? SelectedSizeRangeID { get; set; }
        public double? OpeningDiameter { get; set; }
        public double? Width { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
    }
}
