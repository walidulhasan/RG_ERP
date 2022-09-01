using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class BcdbackUp
    {
        public long Sno { get; set; }
        public long? StockTransactionId { get; set; }
        public string BarCodeNo { get; set; }
        public DateTime? Dated { get; set; }
        public long? SerialNo { get; set; }
        public int? MrpitemCode { get; set; }
        public long? DocumentTypeId { get; set; }
        public long? StyleId { get; set; }
        public long? SizeId { get; set; }
        public long? ColorId { get; set; }
        public int? QualityId { get; set; }
        public int? UserId { get; set; }
        public long? ChallanId { get; set; }
        public int? IsMasterBarcode { get; set; }
    }
}
