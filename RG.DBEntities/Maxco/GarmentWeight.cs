using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GarmentWeight
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public double Weight { get; set; }
        public int UnitId { get; set; }
    }
}
