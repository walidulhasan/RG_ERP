using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsIssuanceDetail
    {
        public long Id { get; set; }
        public long? IssuanceId { get; set; }
        public long? ReceivingId { get; set; }
    }
}
