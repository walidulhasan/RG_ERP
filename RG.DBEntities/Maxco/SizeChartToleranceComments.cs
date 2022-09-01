using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartToleranceComments
    {
        public int Id { get; set; }
        public double? Tolerance { get; set; }
        public string PointToMeasure { get; set; }
        public short? PlacementPointId { get; set; }
        public int? VersionId { get; set; }
        public int? SizeChartCommentsId { get; set; }
        public string Other { get; set; }
        public string SizeChartImage { get; set; }

        public virtual PlacementPointSetup PlacementPoint { get; set; }
        public virtual SizeChartCommentsSetup SizeChartComments { get; set; }
        public virtual SizeChartVersions Version { get; set; }
    }
}
