using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingPartOk
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public long? TtlCutPc { get; set; }
        public long? TtlOkCutPc { get; set; }
        public string Comment { get; set; }
        public DateTime? InspectionDate { get; set; }
        public long? UserId { get; set; }
        public long? CuttingNo { get; set; }
        public long? ChallanId { get; set; }
        public string Inspectorname { get; set; }
    }
}
