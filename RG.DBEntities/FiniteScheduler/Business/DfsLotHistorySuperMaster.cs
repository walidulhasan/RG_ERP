using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DfsLotHistorySuperMaster
    {
        public long Hid { get; set; }
        public long? PreviousLotId { get; set; }
        public string PreviousLotNumber { get; set; }
        public long? UpdateLotId { get; set; }
        public string UpdateLotNumber { get; set; }
        public DateTime? Dated { get; set; }
        public long? UserId { get; set; }
        public string Comments { get; set; }
    }
}
