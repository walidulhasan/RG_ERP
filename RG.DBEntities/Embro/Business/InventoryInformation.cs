using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class InventoryInformation
    {
        public int ItemId { get; set; }
        public decimal ParentId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int? StoreId { get; set; }
        public decimal? OpeningInventory { get; set; }
        public string Units { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }

        public virtual BasicCOA Parent { get; set; }
        public virtual StoresInformation Store { get; set; }
    }
}
