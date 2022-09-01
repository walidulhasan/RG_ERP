using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangerSize
    {
        public int ID { get; set; }
        public long ObjectID { get; set; }
        public double Length { get; set; }
        public long SelectedSizeRangeID { get; set; }
        public double Weight { get; set; }
    }
}
