using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoWorkOrder
    {
        public int Id { get; set; }
        public string WorkOrderNo { get; set; }
        public int SigningAuthorityId { get; set; }
        public int SupplierId { get; set; }
        public int? ContactPersonId { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? ParentWoid { get; set; }
        public int? VersionNo { get; set; }
        public int? OriginalPoid { get; set; }
        public int? RevisionReasonId { get; set; }
        public int? PriceSelection { get; set; }
        public int? LocationSelection { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int? Consolidate { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? NoOfDays { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
