using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsJobDetail
    {
        public long JobDetailId { get; set; }
        public long JobChallanId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int JobQuantity { get; set; }

        public virtual WfsJobChallan JobChallan { get; set; }
    }
}
