using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotHistorySourceDetail
    {
        public long Id { get; set; }
        public long? Lsid { get; set; }
        public string RollNumber { get; set; }
        public double? Quantity { get; set; }
        public long? AttributeInstanceId { get; set; }
    }
}
