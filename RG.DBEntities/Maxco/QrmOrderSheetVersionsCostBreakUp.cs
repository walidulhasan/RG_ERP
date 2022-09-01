using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetVersionsCostBreakUp
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? IsProcessed { get; set; }
        public double? AvgCostingPrice { get; set; }
        public double? AvgNegotiatedPrice { get; set; }
        public double? TotalOrderQty { get; set; }
        public double? TotalFabricCost { get; set; }
    }
}
