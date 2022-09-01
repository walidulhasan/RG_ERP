using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class TrimInventoryQuantity
    {
        public TrimInventoryQuantity()
        {
            TrimAdjustmentDetail = new HashSet<TrimAdjustmentDetail>();
            TrimInspectionDetail = new HashSet<TrimInspectionDetail>();
            TrimIssueDetail = new HashSet<TrimIssueDetail>();
            TrimReturnDetail = new HashSet<TrimReturnDetail>();
            TrimTransferDetail = new HashSet<TrimTransferDetail>();
        }
        public int Id { get; set; }
        public int TrimIqid { get; set; }
        public int TrimInventoryId { get; set; }
        public double Quantity { get; set; }
        public double LeftOverQty { get; set; }
        public int UnitId { get; set; }
        public double? Rate { get; set; }
        public int? StoreLocationId { get; set; }
        public byte Status { get; set; }
        public int? BuyerId { get; set; }
        public string Sdrno { get; set; }
        public string OrderNo { get; set; }

        public virtual StoreLocationSetup StoreLocation { get; set; }
        public virtual TrimInventory TrimInventory { get; set; }
        public virtual MrpitemUnits Unit { get; set; }
        public virtual ICollection<TrimAdjustmentDetail> TrimAdjustmentDetail { get; set; }
        public virtual ICollection<TrimInspectionDetail> TrimInspectionDetail { get; set; }
        public virtual ICollection<TrimIssueDetail> TrimIssueDetail { get; set; }
        public virtual ICollection<TrimReturnDetail> TrimReturnDetail { get; set; }
        public virtual ICollection<TrimTransferDetail> TrimTransferDetail { get; set; }
    }
}
