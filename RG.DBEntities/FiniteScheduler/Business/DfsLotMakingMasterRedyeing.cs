using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotMakingMasterRedyeing
    {
        public long LotId { get; set; }
        public string LotNo { get; set; }
        public DateTime CreationDate { get; set; }
        public long? UserId { get; set; }
        public bool? Status { get; set; }
        public string Comments { get; set; }
    }
}
