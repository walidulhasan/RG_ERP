using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsLotMakingMaster
    {
        public long Id { get; set; }
        public string LotNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? ProcessId { get; set; }
        public long? UserId { get; set; }
        public int? Status { get; set; }
        public string Comments { get; set; }
        public int? IsMachine { get; set; }
    }
}
