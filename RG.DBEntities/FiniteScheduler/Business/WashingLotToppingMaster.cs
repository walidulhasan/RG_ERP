using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotToppingMaster
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Comments { get; set; }
        public long? RequisitionId { get; set; }
        public int? UserId { get; set; }
    }
}
