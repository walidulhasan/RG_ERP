using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DFS_ConfirmationMaster
    {
        public long ID { get; set; }
        public long? LotID { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public long? UserID { get; set; }
        public byte? STATUS { get; set; }
    }
}
