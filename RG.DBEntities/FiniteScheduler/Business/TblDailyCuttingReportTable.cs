using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDailyCuttingReportTable
    {
        public string OrderNo { get; set; }
        public long? StyleId { get; set; }
        public string StyleName { get; set; }
        public long? ColorId { get; set; }
        public string ColorName { get; set; }
        public long? SizeId { get; set; }
        public string SizeName { get; set; }
        public long? PatternPieceId { get; set; }
        public long? OrderQty { get; set; }
        public long? PreviousCutQty { get; set; }
        public long? ProducedGarmentQty { get; set; }
        public string Comments { get; set; }
    }
}
