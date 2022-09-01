using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsWoIssuanceMaster
    {
        public long Id { get; set; }
        public long? Dcid { get; set; }
        public long LotId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public long? UserId { get; set; }
        public int IsReceived { get; set; }
    }
}
