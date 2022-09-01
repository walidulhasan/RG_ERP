using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CmtWochallanMaster
    {
        public long ChallanId { get; set; }
        public long WomasterId { get; set; }
        public long? StyleId { get; set; }
        public DateTime? ChallanDate { get; set; }
        public long? Status { get; set; }
        public string Comments { get; set; }
    }
}
