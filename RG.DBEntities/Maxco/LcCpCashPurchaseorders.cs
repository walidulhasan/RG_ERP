using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class LcCpCashPurchaseorders
    {
   [Key]
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
