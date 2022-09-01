using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeOpeningBalanceFlatbedDetail
    {
        public long Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int Quantity { get; set; }
        public double QuantityInKgs { get; set; }
        public double RatePerPieces { get; set; }
        public double Amount { get; set; }
        public double? SkgLength { get; set; }
        public double? SkgWidth { get; set; }
    }
}
