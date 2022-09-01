using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialAdjustmentMaster
    {
        public int Id { get; set; }
        public int MadjustmentMid { get; set; }
        public DateTime AdjustmentDate { get; set; }
    }
}
