using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsReDyeingConfirmationMaster
    {
        public long ConformationId { get; set; }
        public long LotId { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public long? UserId { get; set; }
        public bool Status { get; set; }
        public string Comments { get; set; }
    }
}
