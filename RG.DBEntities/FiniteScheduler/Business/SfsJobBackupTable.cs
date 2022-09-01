using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobBackupTable
    {
        public long? JobId { get; set; }
        public long? StyleId { get; set; }
        public int? Status { get; set; }
        public long? SfsPrsid { get; set; }
        public long? StartWcdayId { get; set; }
        public int? StartMinuteId { get; set; }
        public long? EndWcdayId { get; set; }
        public int? EndMinuteId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
