using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartSpecificationSetup
    {
        public int Id { get; set; }
        public int PlacementPointId { get; set; }
        public int MeasurementScaleId { get; set; }
        public long SizeRangeId { get; set; }
        public double? MeasurementFraction { get; set; }
        public int SizeChartId { get; set; }
        public int? Measurement { get; set; }

        public virtual SizeChartMainSetup SizeChart { get; set; }
    }
}
