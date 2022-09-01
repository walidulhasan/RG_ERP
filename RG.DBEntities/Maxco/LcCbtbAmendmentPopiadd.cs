using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCbtbAmendmentPopiadd
    {
        public int Id { get; set; }
        public int LcpId { get; set; }
        public int Amdmaster { get; set; }
        public int LcpPoid { get; set; }
        public string LcpVpi { get; set; }
        public DateTime? LcpPidate { get; set; }
        public decimal? LcpRate { get; set; }
        public decimal? LcpQuantity { get; set; }
        public int? LcpCurrencyid { get; set; }
        public decimal? LcpConversionrate { get; set; }
        public long? LcpOrderid { get; set; }
        public long? LcpAttributeinstenceid { get; set; }
        public long? LcpUnitid { get; set; }
        public string LcpStore { get; set; }
    }
}
