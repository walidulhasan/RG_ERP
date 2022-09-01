using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartSpecification
    {
        public int Id { get; set; }
        public short PlacementPointId { get; set; }
        public double Measurement { get; set; }
        public byte MeasurementScaleId { get; set; }
        public int SelectedSizeRangeId { get; set; }
        public int VersionId { get; set; }
        public double? MeasurementFraction { get; set; }
        public int? DimensionId { get; set; }

        public virtual PlacementPointSetup PlacementPoint { get; set; }
        public virtual SizeChartVersions Version { get; set; }
    }
}
