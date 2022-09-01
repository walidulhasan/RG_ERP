using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VBarcodeTraceModelwise
    {
        public string BarCodeNo { get; set; }
        public DateTime? Dated { get; set; }
        public int? MrpitemCode { get; set; }
        public string Description { get; set; }
        public int? QualityId { get; set; }
        public int? IsMasterBarcode { get; set; }
        public string Mname { get; set; }
    }
}
