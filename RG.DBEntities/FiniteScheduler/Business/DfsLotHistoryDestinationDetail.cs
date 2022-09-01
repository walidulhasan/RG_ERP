using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotHistoryDestinationDetail
    {
        public long Id { get; set; }
        public long? Ldid { get; set; }
        public string RollNumber { get; set; }
        public double? Quantity { get; set; }
        public long? AttributeInstanceId { get; set; }
    }
}
