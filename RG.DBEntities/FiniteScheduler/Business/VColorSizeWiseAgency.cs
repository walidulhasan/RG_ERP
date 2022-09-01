using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VColorSizeWiseAgency
    {
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int? PatternPieceId { get; set; }
        public double? Expr1 { get; set; }
        public long TransCode { get; set; }
    }
}
