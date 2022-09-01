using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsCuttingPermanentRejection
    {
        public long Id { get; set; }
        public string RejectionNumber { get; set; }
        public long FsReceivingLotsVariationId { get; set; }
        public long TempReceivingId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
