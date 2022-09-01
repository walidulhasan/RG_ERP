using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnWorkOrderIssueMaster
    {
        public long WorkOrderIssueId { get; set; }
        public long WorkOrderId { get; set; }
        public DateTime? IssuanceDate { get; set; }
    }
}
