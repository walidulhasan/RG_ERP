using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GarmentFinishingSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Smvvalue { get; set; }
        public string OperationRate { get; set; }
        public int? IsFinishing { get; set; }
    }
}
