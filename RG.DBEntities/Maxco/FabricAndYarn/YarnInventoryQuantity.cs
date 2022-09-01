using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnInventoryQuantity
    {
        public YarnInventoryQuantity()
        {
            YarnReturnDetail = new HashSet<YarnReturnDetail>();
        }
        [Key]
        public int YarnIqid { get; set; }
        public int YarnInventoryId { get; set; }
        public double Quantity { get; set; }
        public double LeftOverQty { get; set; }
        public int? UnitId { get; set; }
        public double? ConversiontoSku { get; set; }
        public double? Rate { get; set; }
        public int Status { get; set; }
        public int? NoofCones { get; set; }

        public virtual YarnInventory YarnInventory { get; set; }
        public virtual ICollection<YarnReturnDetail> YarnReturnDetail { get; set; }
    }
}
