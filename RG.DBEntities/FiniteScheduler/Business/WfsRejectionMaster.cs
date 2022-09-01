using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsRejectionMaster
    {
        public long RejectionId { get; set; }
        public long JobId { get; set; }
        public DateTime RejectionDate { get; set; }
    }
}
