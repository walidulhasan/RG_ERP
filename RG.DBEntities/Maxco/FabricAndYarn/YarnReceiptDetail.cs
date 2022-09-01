using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnReceiptDetail
    {
        [Key]
        public int YarnReceiptDetailId { get; set; }
        public int Mrmid { get; set; }
        public int YarnInventoryId { get; set; }
        public int? Knitter { get; set; }
        public string KnitterContractNo { get; set; }
        public string Source { get; set; }
        public int? Mpodid { get; set; }

        public virtual YarnPodeliveries Mpod { get; set; }
        public virtual YarnInventory YarnInventory { get; set; }
    }
}
