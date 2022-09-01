using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmFabricDimensionVariantWise
    {
        public int Id { get; set; }
        public int? SizeId { get; set; }
        public int? FabricId { get; set; }
        public decimal? FinishWidth { get; set; }
        public decimal? FinishLength { get; set; }
        public int? WidthUnitId { get; set; }
        public int? LengthUnitId { get; set; }
        public double? SalvageWidth { get; set; }
        public double? SalvageLength { get; set; }
        public double? Consumption { get; set; }
    }
}
