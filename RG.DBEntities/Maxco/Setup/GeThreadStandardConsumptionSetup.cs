using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GeThreadStandardConsumptionSetup
    {
        public int Id { get; set; }
        public int MachineTypeId { get; set; }
        public double? ThreadConsumption { get; set; }
        public double? LopperConsumption { get; set; }
        public double? NeedleConsumption { get; set; }
        public int? GarmentType { get; set; }
    }
}
