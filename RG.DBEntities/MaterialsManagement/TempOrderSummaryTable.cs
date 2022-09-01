using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TempOrderSummaryTable
    {
        public long? OrderId { get; set; }
        public string OrderNo { get; set; }
        public long? StyleId { get; set; }
        public string StyleName { get; set; }
        public long? OrderQty { get; set; }
        public long? CutProd { get; set; }
        public long? CutIss { get; set; }
        public long? CutRej { get; set; }
        public long? StRec { get; set; }
        public long? InLine { get; set; }
        public long? OffLine { get; set; }
        public long? StIss { get; set; }
        public long? FinRec { get; set; }
        public long? PackedA { get; set; }
        public long? PackedB { get; set; }
        public long? PackedRej { get; set; }
        public long? ShipQty { get; set; }
        public long? ShipBqty { get; set; }
    }
}
