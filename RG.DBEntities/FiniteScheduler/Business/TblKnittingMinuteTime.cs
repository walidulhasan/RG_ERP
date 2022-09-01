using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingMinuteTime
    {
        public int MinuteId { get; set; }
        public DateTime DayMinute { get; set; }
        public int MinuteTypeId { get; set; }
        public short? WorkSpanSeq { get; set; }
    }
}
