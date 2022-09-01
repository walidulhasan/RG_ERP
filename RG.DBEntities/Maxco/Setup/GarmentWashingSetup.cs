using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GarmentWashingSetup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Smv { get; set; }
        public double Rate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
