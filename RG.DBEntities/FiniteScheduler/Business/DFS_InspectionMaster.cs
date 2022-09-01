using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DFS_InspectionMaster
    {
        public long ID { get; set; }
        public long? LotID { get; set; }
        public DateTime? InspectionDate { get; set; }
        public long? UserID { get; set; }
        public string Comments { get; set; }
    }
}
