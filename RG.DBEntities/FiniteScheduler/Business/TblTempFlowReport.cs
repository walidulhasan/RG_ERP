using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblTempFlowReport
    {
        public string OrderName { get; set; }
        public string StyleName { get; set; }
        public decimal? ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal? SizeId { get; set; }
        public string Description { get; set; }
        public decimal? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public string Dated { get; set; }
        public string Mname { get; set; }
        public string OperationName { get; set; }
        public decimal? Qty { get; set; }
    }
}
