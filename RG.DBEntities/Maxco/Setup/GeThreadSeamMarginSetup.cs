using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GeThreadSeamMarginSetup
    {
        public int Id { get; set; }
        public int MachineTypeId { get; set; }
        public double SeamMargin { get; set; }
        public int? GarmentType { get; set; }
    }
}
