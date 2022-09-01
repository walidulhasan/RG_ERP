using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SizeChartCommentsSetup
    {
        public SizeChartCommentsSetup()
        {
            SizeChartToleranceComments = new HashSet<SizeChartToleranceComments>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public short? PlacementPointId { get; set; }

        public virtual PlacementPointSetup PlacementPoint { get; set; }
        public virtual ICollection<SizeChartToleranceComments> SizeChartToleranceComments { get; set; }
    }
}
