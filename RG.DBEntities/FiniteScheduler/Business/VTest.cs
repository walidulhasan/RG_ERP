using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VTest
    {
        public decimal? OrderId { get; set; }
        public string OrderName { get; set; }
        public decimal? StyleId { get; set; }
        public decimal? AssignedStyleId { get; set; }
        public string StyleName { get; set; }
        public decimal? ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public decimal? OrderQty { get; set; }
        public long? Expr1 { get; set; }
    }
}
