using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingExecutionPlanMaster
    {
        public long Id { get; set; }
        public long? StyleId { get; set; }
        public long? ColorSetId { get; set; }
        public DateTime? Rdate { get; set; }
        public int? UserId { get; set; }
        public string VariationNo { get; set; }
        public bool? Firmed { get; set; }
        public int? FirmedBy { get; set; }
        public DateTime? FirmedOn { get; set; }
    }
}
