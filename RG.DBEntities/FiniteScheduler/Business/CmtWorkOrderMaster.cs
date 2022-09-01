using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CmtWorkOrderMaster
    {
        public long CmtWorkOrderMasterId { get; set; }
        public int? CmtAgencyId { get; set; }
        public long? CmtBcocode { get; set; }
        public long? CmtCodeId { get; set; }
        public long? CmtModeOfPaymentId { get; set; }
        public long? CmtTermsOfPaymentId { get; set; }
        public long? CmtPaymentDays { get; set; }
        public double? CmtPerPieceRate { get; set; }
        public long? CmtCurrencyId { get; set; }
        public long? CmtDeliveryDestinationId { get; set; }
        public DateTime? CmtDeliveryDate { get; set; }
        public long? CmtNoOfDelivery { get; set; }
        public long? CmtStyleId { get; set; }
        public long? UserId { get; set; }
        public bool? IsGarment { get; set; }
    }
}
