using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedPurchaseOrderFabrics
    {
        public int Id { get; set; }
        public int Poid { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? UnitId { get; set; }
        public int? MrpitemCode { get; set; }
        public double? Quantity { get; set; }
        public double? Balance { get; set; }
        public double? Rate { get; set; }
        public string PantoneNo { get; set; }
        public int? MatchingSourceId { get; set; }
        public int? FinishingCodeId { get; set; }

        public virtual DyedPurchaseOrderMaster Po { get; set; }
    }
}
