using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobHistory
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long SfsPrsid { get; set; }
        public long? StartWcdayId { get; set; }
        public int? StartMinuteId { get; set; }
        public long? EndWcdayId { get; set; }
        public long? EndMinuteId { get; set; }
    }
}
