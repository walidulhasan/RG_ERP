using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartScannedImage
    {
        public int Id { get; set; }
        public long SizeChartSelectedElementId { get; set; }
        public long StyleId { get; set; }
        public string ImagePath { get; set; }
    }
}
