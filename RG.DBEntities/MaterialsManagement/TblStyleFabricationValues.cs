using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblStyleFabricationValues
    {
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long FabricId { get; set; }
        public double StandardPrice { get; set; }
        public double StandardWidth { get; set; }
        public double ActualWidth { get; set; }
        public double StandardConsumption { get; set; }
        public double ActualConsumption { get; set; }
    }
}
