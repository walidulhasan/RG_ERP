using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnReturnDetail
    {
        [Key]
        public int YreturnDid { get; set; }
        public int MreturnMid { get; set; }
        public int ReceiptYarnIqid { get; set; }
        public int ReturnYarnInventoryId { get; set; }
        public int ReasonId { get; set; }

        public virtual YarnInventoryQuantity ReceiptYarnIq { get; set; }
        public virtual YarnInventory ReturnYarnInventory { get; set; }
    }
}
