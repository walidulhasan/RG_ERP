using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AcBalanceFabricStockBk
    {
        public int Id { get; set; }
        public long? OrderId { get; set; }
        public long? ColorId { get; set; }
        public long? StyleId { get; set; }
        public long? AttributeinstanceId { get; set; }
        public double? OrderQty { get; set; }
        public double? CutQty { get; set; }
        public double? CutCost { get; set; }
        public double? FabricCostStd { get; set; }
        public double? FabricInCutStore { get; set; }
        public double? ActualFabricCons { get; set; }
        public double? StdGsm { get; set; }
        public double? ActualGsm { get; set; }
        public double? RateOfFabric { get; set; }
        public DateTime? TransDate { get; set; }
        public double? PrvCutQty { get; set; }
        public double? LeftOver { get; set; }
        public double? CuttingWastage { get; set; }
        public double? Scrap { get; set; }
    }
}
