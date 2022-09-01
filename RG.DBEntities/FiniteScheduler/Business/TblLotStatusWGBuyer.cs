using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblLotStatusWGBuyer
    {
        public int LotStatusId { get; set; }
        public long? Lotid { get; set; }
        public string LotComment { get; set; }
        public DateTime? LotEntryDate { get; set; }
        public long? UserId { get; set; }
    }
}
