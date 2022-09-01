using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class MrpitemUnits
    {
        public MrpitemUnits()
        {
            TrimInventoryQuantity = new HashSet<TrimInventoryQuantity>();
            YarnPodeliveries = new HashSet<YarnPodeliveries>();
        }
        public int Id { get; set; }
        public int MrpitemUnitId { get; set; }
        public int MrpunitsId { get; set; }
        public int MrpitemCode { get; set; }
        public double? ConversiontoSku { get; set; }

        public virtual ICollection<TrimInventoryQuantity> TrimInventoryQuantity { get; set; }
        public virtual ICollection<YarnPodeliveries> YarnPodeliveries { get; set; }
    }
}
