using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CmtChallanReceicveMaster
    {
        public long ReceiveId { get; set; }
        public long? ChallanId { get; set; }
        public long? WomasterId { get; set; }
        public long? StyleId { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string Comments { get; set; }
    }
}
