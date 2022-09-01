using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsReceivingChallanDetail
    {
        public long ReceivingDetailId { get; set; }
        public long ReceivingMasterId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int GarmentQuantity { get; set; }

        public virtual WfsReceivingChallanMaster ReceivingMaster { get; set; }
    }
}
