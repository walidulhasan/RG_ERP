using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsAuditMaster
    {
        public SfsAuditMaster()
        {
            SfsAuditDetail = new HashSet<SfsAuditDetail>();
        }

        public long Id { get; set; }
        public string Barcode { get; set; }
        public string Style { get; set; }
        public string Order { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public long StyleId { get; set; }
        public byte? GarmentStatusId { get; set; }
        public long? JobId { get; set; }
        public int? IsFinishing { get; set; }
        public long? AuditId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual SfsConfirmationNauditAssociation Audit { get; set; }
        public virtual ICollection<SfsAuditDetail> SfsAuditDetail { get; set; }
    }
}
