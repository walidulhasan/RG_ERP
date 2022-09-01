using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class StitchingRec
    {
        public long ReceivingMasterId { get; set; }
        public long ColorId { get; set; }
        public long? Qty { get; set; }
    }
}
