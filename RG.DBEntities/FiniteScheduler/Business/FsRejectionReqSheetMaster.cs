using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRejectionReqSheetMaster
    {
        public long RejectionSfsmasterId { get; set; }
        public string RejectionSfsno { get; set; }
        public int? Status { get; set; }
    }
}
