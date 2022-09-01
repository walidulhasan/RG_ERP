using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DFS_IssuanceMaster 
    {
        public long ID { get; set; }
        public long? DCID { get; set; }
        public long? LotID { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public long? UserID { get; set; }
        public bool? isReceived { get; set; }
    }
}
