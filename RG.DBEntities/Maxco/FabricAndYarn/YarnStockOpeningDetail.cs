using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnStockOpeningDetail
    {
        [Key]
        public int Ysodid { get; set; }
        public long Msomid { get; set; }
        public int YarnInventoryId { get; set; }

        public virtual YarnInventory YarnInventory { get; set; }
    }
}
