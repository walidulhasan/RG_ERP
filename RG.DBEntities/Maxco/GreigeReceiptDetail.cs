using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeReceiptDetail
    {[Key]
        public int GreigeReceiptDetailId { get; set; }
        public int Mrmid { get; set; }
        public int GreigeInventoryId { get; set; }
    }
}
