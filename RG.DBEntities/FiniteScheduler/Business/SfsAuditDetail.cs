using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsAuditDetail
    {
        public long Id { get; set; }
        public long AuditMasterId { get; set; }
        public int VersionNo { get; set; }
        public byte[] DefGarFrontImg { get; set; }
        public byte[] DefGarBackImg { get; set; }

        public virtual SfsAuditMaster AuditMaster { get; set; }
    }
}
