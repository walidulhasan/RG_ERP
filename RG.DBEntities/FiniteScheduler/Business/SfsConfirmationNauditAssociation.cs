using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsConfirmationNauditAssociation
    {
        public SfsConfirmationNauditAssociation()
        {
            SfsAuditMaster = new HashSet<SfsAuditMaster>();
        }

        public long AuditId { get; set; }
        public long ConfirmationId { get; set; }
        public string AuditComments { get; set; }
        public DateTime? AuditDate { get; set; }
        public string UserId { get; set; }
        public bool? AuditStatus { get; set; }
        public DateTime? AuditApprovalDate { get; set; }

        public virtual SfsJobConfirmation Confirmation { get; set; }
        public virtual ICollection<SfsAuditMaster> SfsAuditMaster { get; set; }
    }
}
