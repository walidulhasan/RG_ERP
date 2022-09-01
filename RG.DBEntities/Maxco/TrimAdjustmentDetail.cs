using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimAdjustmentDetail
    {
        public int Id { get; set; }
        public int TadjustmentDid { get; set; }
        public int? MadjustmentMid { get; set; }
        public int? TrimIqid { get; set; }
        public int? AdjustedQuantity { get; set; }
        public int? MadjustmentReasonId { get; set; }

        public virtual TrimInventoryQuantity TrimIq { get; set; }
    }
}
