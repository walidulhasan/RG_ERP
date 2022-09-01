using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingWorkOrderMaster
    {
        public long WorkOrerId { get; set; }
        public long JobId { get; set; }
        public string WorkOrderNo { get; set; }
        public DateTime CreationDate { get; set; }
        public int PickListId { get; set; }
        public int SubPickListId { get; set; }
    }
}
