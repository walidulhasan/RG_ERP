using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsWoinspectionMaster
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public long? UserId { get; set; }
        public int? Status { get; set; }
        public string Comments { get; set; }
    }
}
