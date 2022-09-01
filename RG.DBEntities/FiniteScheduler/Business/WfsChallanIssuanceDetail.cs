using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsChallanIssuanceDetail
    {
        public long IssuanceDetailId { get; set; }
        public long IssuanceChallanId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int GarmentQuantity { get; set; }

        public virtual WfsChallanIssuance IssuanceChallan { get; set; }
    }
}
