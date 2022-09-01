using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimInventory
    {
        public TrimInventory()
        {
            TrimInventoryQuantity = new HashSet<TrimInventoryQuantity>();
            TrimStockOpeningDetail = new HashSet<TrimStockOpeningDetail>();
        }
        public int Id { get; set; }
        public int TrimInventoryId { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual ICollection<TrimInventoryQuantity> TrimInventoryQuantity { get; set; }
        public virtual ICollection<TrimStockOpeningDetail> TrimStockOpeningDetail { get; set; }
    }
}
