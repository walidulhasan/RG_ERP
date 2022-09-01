using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PlacementPointSequenceSetup
    {
        public int Id { get; set; }
        public int PlacementPointId { get; set; }
        public int PlacementPointSequence { get; set; }
        public bool IsFabricUsage { get; set; }
        public int SizeChartId { get; set; }
    }
}
