using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartToleranceSetup
    {
        public int Id { get; set; }
        public int? SizeChartId { get; set; }
        public double? Tolerance { get; set; }
        public int? PlacementPointId { get; set; }
        public string Other { get; set; }
        public string SizeChartImage { get; set; }
    }
}
