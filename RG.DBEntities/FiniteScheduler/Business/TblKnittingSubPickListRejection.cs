using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingSubPickListRejection
    {
        public long RejectionId { get; set; }
        public string RejectionNo { get; set; }
        public long SubPickListId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status { get; set; }
    }
}
