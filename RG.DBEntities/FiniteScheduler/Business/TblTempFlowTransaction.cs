using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblTempFlowTransaction
    {
        public decimal? OrderId { get; set; }
        public string OrderName { get; set; }
        public decimal? StyleId { get; set; }
        public string StyleName { get; set; }
        public decimal? ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal? SizeId { get; set; }
        public string Description { get; set; }
        public decimal? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public decimal? Qty { get; set; }
        public decimal? TransType { get; set; }
        public decimal? WorkCenterId { get; set; }
    }
}
