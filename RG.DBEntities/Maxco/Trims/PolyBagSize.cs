using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class PolyBagSize
    {
        public int ID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? FlapLength { get; set; }
        public long? SelectedSizeRangeID { get; set; }
        [ForeignKey("PolyBagSpecification")]
        public long? ObjectID { get; set; }

        public PolyBagSpecification PolyBagSpecification { get; set; }
    }
}
