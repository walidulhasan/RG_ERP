using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialReceiptDetail
    {[Key]
        public int Mrdid { get; set; }
        public int Mrmid { get; set; }
        public int YarnInventoryId { get; set; }
    }
}
