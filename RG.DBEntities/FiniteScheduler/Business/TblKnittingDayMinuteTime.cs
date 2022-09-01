using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingDayMinuteTime
    {
        public int DayMinuteId { get; set; }
        public int DayId { get; set; }
        public int MinuteId { get; set; }
        public int? StatusId { get; set; }
    }
}
