using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class StoreLocationSetup
    {
        public StoreLocationSetup()
        {
            TrimInspectionDetail = new HashSet<TrimInspectionDetail>();
            TrimInventoryQuantity = new HashSet<TrimInventoryQuantity>();
            YarnInventory = new HashSet<YarnInventory>();
        }
        public int Id { get; set; }
        public int StoreLocationId { get; set; }
        public string StoreLocationDesc { get; set; }
        public bool Quarantine { get; set; }
        public int StoreId { get; set; }
        public int? StoreLocationType { get; set; }

        public virtual StoreSetup Store { get; set; }
        public virtual ICollection<TrimInspectionDetail> TrimInspectionDetail { get; set; }
        public virtual ICollection<TrimInventoryQuantity> TrimInventoryQuantity { get; set; }
        public virtual ICollection<YarnInventory> YarnInventory { get; set; }
    }
}
