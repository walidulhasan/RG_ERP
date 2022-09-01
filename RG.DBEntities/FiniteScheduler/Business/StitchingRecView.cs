using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class StitchingRecView
    {
        public long StyleId { get; set; }
        public long ReceivingMasterId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long? Qty { get; set; }
        public DateTime Date { get; set; }
    }
}
