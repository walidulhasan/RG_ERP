using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyDateWiseReport
    {
        public int? IssuanceAgencyId { get; set; }
        public int? ReceiveAgencyId { get; set; }
        public string OrderNo { get; set; }
        public long? ChallanNo { get; set; }
        public long? StyleId { get; set; }
        public string Style { get; set; }
        public long? BundleId { get; set; }
        public int? BundleNo { get; set; }
        public long? ColorId { get; set; }
        public string Color { get; set; }
        public long? SizeId { get; set; }
        public string Size { get; set; }
        public long? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public double? ReceivedQuantity { get; set; }
        public double? IssuedQuantity { get; set; }
    }
}
