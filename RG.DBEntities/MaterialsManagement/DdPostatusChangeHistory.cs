using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPostatusChangeHistory
    {
        public long PurchaseOrderId { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int? ReasonId { get; set; }
        public DateTime? DispatchDate { get; set; }
        public string DispatchTo { get; set; }
        public int? DispatchTypeId { get; set; }

        public virtual DdPurchaseOrder PurchaseOrder { get; set; }
    }
}
