using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdPoinstructions
    {
        public int Id { get; set; }
        public long PurchaseOrderId { get; set; }
        public string Instruction { get; set; }

        public virtual DdPurchaseOrder PurchaseOrder { get; set; }
    }
}
