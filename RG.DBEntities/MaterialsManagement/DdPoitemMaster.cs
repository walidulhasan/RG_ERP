using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPoitemMaster
    {
        public DdPoitemMaster()
        {
            DdPoitemDetails = new HashSet<DdPoitemDetails>();
        }

        public int Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? UnitId { get; set; }
        public int? OrderId { get; set; }
        public int? ObjectId { get; set; }
        public int? RequisitionId { get; set; }
        public int? MrpitemCode { get; set; }
        public int? IsMrpbased { get; set; }
        public int? ModelId { get; set; }
        public long? NewAttributeInstance { get; set; }
        public bool? IsNewAttributeInstance { get; set; }

        public virtual DdPurchaseOrder PurchaseOrder { get; set; }
        public virtual ICollection<DdPoitemDetails> DdPoitemDetails { get; set; }
    }
}
