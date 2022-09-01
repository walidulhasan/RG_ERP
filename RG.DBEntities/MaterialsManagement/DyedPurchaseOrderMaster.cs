using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedPurchaseOrderMaster
    {
        public DyedPurchaseOrderMaster()
        {
            DyedPurchaseOrderDetail = new HashSet<DyedPurchaseOrderDetail>();
            DyedPurchaseOrderFabrics = new HashSet<DyedPurchaseOrderFabrics>();
        }

        public int Id { get; set; }
        public string Pono { get; set; }
        public int? SigningAuthorityId { get; set; }
        public int? SupplierId { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }

        public virtual ICollection<DyedPurchaseOrderDetail> DyedPurchaseOrderDetail { get; set; }
        public virtual ICollection<DyedPurchaseOrderFabrics> DyedPurchaseOrderFabrics { get; set; }
    }
}
