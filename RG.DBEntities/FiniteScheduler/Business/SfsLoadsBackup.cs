using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsLoadsBackup
    {
        public long FixedAssetId { get; set; }
        public int MinuteId { get; set; }
        public long WcdayId { get; set; }
        public long SfsJobTicketId { get; set; }
        public int Deleted { get; set; }
        public long Id { get; set; }
    }
}
