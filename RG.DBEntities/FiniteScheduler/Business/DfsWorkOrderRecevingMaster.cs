using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsWorkOrderRecevingMaster
    {
        public long WorkOrderRecevId { get; set; }
        public long WorkOrderId { get; set; }
        public string WoRecevingNo { get; set; }
        public DateTime WoRecevingDate { get; set; }
        public string Comments { get; set; }
        public long UserId { get; set; }
    }
}
