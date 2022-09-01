using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmMaterialStockOpening
    {
        public long Msoid { get; set; }
        public DateTime? Obdate { get; set; }
        public int Status { get; set; }
    }
}
