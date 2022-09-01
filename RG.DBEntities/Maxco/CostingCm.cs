using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CostingCm
    {
        public int Id { get; set; }
        public long Orderid { get; set; }
        public string OderNo { get; set; }
        public double? CostingCm1 { get; set; }
        public double? Dyeingrate { get; set; }
    }
}
