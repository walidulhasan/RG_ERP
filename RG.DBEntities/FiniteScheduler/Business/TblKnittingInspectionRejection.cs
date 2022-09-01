using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingInspectionRejection
    {
        public int Id { get; set; }
        public long Ykncid { get; set; }
        public long JobId { get; set; }
        public long RollId { get; set; }
        public string RollCode { get; set; }
        public long RejQuantity { get; set; }
    }
}
