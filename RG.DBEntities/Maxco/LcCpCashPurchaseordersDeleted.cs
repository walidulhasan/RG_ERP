using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCpCashPurchaseordersDeleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }
        public int LcpId { get; set; }
        public int LcmId { get; set; }
        public int LcpPoid { get; set; }
        public string LcpVpi { get; set; }
        public DateTime? LcpPidate { get; set; }
        public decimal? LcpRate { get; set; }
        public decimal? LcpQuantity { get; set; }
        public int? LcpCurrencyid { get; set; }
        public decimal? LcpConversionrate { get; set; }
    }
}
