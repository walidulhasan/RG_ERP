using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PlacementPointSetup
    {
        public PlacementPointSetup()
        {
            PlacementPointSequence = new HashSet<PlacementPointSequence>();
            SizeChartCommentsSetup = new HashSet<SizeChartCommentsSetup>();
            SizeChartPlacementSetup = new HashSet<SizeChartPlacementSetup>();
            SizeChartSpecification = new HashSet<SizeChartSpecification>();
            SizeChartToleranceComments = new HashSet<SizeChartToleranceComments>();
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public bool? IsFabricUsage { get; set; }
        public byte? GarmentCategoryId { get; set; }
        public byte Status { get; set; }
        public byte? BuyerId { get; set; }

        public virtual ICollection<PlacementPointSequence> PlacementPointSequence { get; set; }
        public virtual ICollection<SizeChartCommentsSetup> SizeChartCommentsSetup { get; set; }
        public virtual ICollection<SizeChartPlacementSetup> SizeChartPlacementSetup { get; set; }
        public virtual ICollection<SizeChartSpecification> SizeChartSpecification { get; set; }
        public virtual ICollection<SizeChartToleranceComments> SizeChartToleranceComments { get; set; }
    }
}
