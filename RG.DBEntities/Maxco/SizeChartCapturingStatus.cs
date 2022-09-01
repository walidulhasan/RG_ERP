using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartCapturingStatus
    {
        public int Id { get; set; }
        public int GarmentTypeId { get; set; }
        public bool IsSizeChartCaptured { get; set; }
    }
}
