using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingLeftOverMaster
    {
        public int CuttingLeftOverId { get; set; }
        public DateTime TransDate { get; set; }
        public long? OrderId { get; set; }
        public long? ModelId { get; set; }
    }
}
