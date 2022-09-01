using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TrimStockOpeningDetail
    {
        public int Id { get; set; }
        public int TrimSodid { get; set; }
        public long Msomid { get; set; }
        public int TrimInventoryId { get; set; }

        public virtual TrimInventory TrimInventory { get; set; }
    }
}
