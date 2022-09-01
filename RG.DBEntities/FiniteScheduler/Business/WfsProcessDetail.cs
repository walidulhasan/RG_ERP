using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsProcessDetail
    {
        public long ProcessDetailId { get; set; }
        public long ProcessMasterId { get; set; }
        public long SumGarmentQuantity { get; set; }

        public virtual WfsProcessMaster ProcessMaster { get; set; }
    }
}
