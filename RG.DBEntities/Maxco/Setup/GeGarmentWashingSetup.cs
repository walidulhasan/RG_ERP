using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GeGarmentWashingSetup
    {
        public int Id { get; set; }
        public long GwId { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public double TargetProduction { get; set; }
    }
}
