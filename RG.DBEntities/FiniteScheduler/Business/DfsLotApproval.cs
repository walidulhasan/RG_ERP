using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotApproval
    {
        public int ApprovalId { get; set; }
        public int LotId { get; set; }
        public int UserId { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Comments { get; set; }
    }
}
