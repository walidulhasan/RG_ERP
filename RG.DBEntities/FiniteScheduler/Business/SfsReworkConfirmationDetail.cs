using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsReworkConfirmationDetail
    {
        public long ConfirmationId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
        public int QualityId { get; set; }
        public long Id { get; set; }
    }
}
