using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPurchaseOrder
    {
        public DdPurchaseOrder()
        {
            DdPoinstructions = new HashSet<DdPoinstructions>();
            DdPoitemMaster = new HashSet<DdPoitemMaster>();
            DdPostatusChangeHistory = new HashSet<DdPostatusChangeHistory>();
        }

        public long Id { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int SigningAuthorityId { get; set; }
        public int SupplierId { get; set; }
        public int? ContactPersonId { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? ParentPoid { get; set; }
        public int? VersionNo { get; set; }
        public int? OriginalPoid { get; set; }
        public int? RevisionReasonId { get; set; }
        public int? PriceSelection { get; set; }
        public int? LocationSelection { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int Consolidate { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? IsImported { get; set; }
        public int? NoOfDays { get; set; }
        public int? IsIndReq { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
        public int? LcmId { get; set; }
        public int? AdvancePercentage { get; set; }

        public virtual DdPostatusSetup StatusNavigation { get; set; }
        public virtual ICollection<DdPoinstructions> DdPoinstructions { get; set; }
        public virtual ICollection<DdPoitemMaster> DdPoitemMaster { get; set; }
        public virtual ICollection<DdPostatusChangeHistory> DdPostatusChangeHistory { get; set; }
    }
}
