using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsReworkBacodes
    {
        public long Id { get; set; }
        public string BarcodeNo { get; set; }
        public DateTime? Dated { get; set; }
        public int? MrpitemCode { get; set; }
        public long? StyleId { get; set; }
        public long? ColorId { get; set; }
        public long? SizeId { get; set; }
        public int? QualityId { get; set; }
        public int? ChallanId { get; set; }
        public int? IsMasterBarcode { get; set; }
    }
}
