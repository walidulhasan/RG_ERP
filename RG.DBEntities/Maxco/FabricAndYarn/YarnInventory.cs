using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;


namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnInventory
    {
        public YarnInventory()
        {
            YarnAdjustmentDetail = new HashSet<YarnAdjustmentDetail>();
            YarnInventoryQuantity = new HashSet<YarnInventoryQuantity>();
            YarnIssueDetail = new HashSet<YarnIssueDetail>();
            YarnReceiptDetail = new HashSet<YarnReceiptDetail>();
            YarnReturnDetail = new HashSet<YarnReturnDetail>();
            YarnStockOpeningDetail = new HashSet<YarnStockOpeningDetail>();
            YarnTransferDetailDestinationYarnInventory = new HashSet<YarnTransferDetail>();
            YarnTransferDetailSourceYarnInventory = new HashSet<YarnTransferDetail>();
        }
        [Key]
        public int YarnInventoryId { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public DateTime? MfgDate { get; set; }
        public int? SupplierId { get; set; }
        public int StoreLocationId { get; set; }
        public string Gst { get; set; }
        public int? BrandId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual StoreLocationSetup StoreLocation { get; set; }
        public virtual ICollection<YarnAdjustmentDetail> YarnAdjustmentDetail { get; set; }
        public virtual ICollection<YarnInventoryQuantity> YarnInventoryQuantity { get; set; }
        public virtual ICollection<YarnIssueDetail> YarnIssueDetail { get; set; }
        public virtual ICollection<YarnReceiptDetail> YarnReceiptDetail { get; set; }
        public virtual ICollection<YarnReturnDetail> YarnReturnDetail { get; set; }
        public virtual ICollection<YarnStockOpeningDetail> YarnStockOpeningDetail { get; set; }
        public virtual ICollection<YarnTransferDetail> YarnTransferDetailDestinationYarnInventory { get; set; }
        public virtual ICollection<YarnTransferDetail> YarnTransferDetailSourceYarnInventory { get; set; }
    }
}
