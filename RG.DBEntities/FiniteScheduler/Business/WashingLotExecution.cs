using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingLotExecution
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public int? UserId { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
