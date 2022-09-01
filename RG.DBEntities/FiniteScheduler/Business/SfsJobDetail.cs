using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobDetail
    {
        public long JobDetailId { get; set; }
        public long JobId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public long Quantity { get; set; }

        public virtual SfsJob Job { get; set; }
    }
}
