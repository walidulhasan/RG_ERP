using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetWashingActual
    {
        public int Id { get; set; }
        public string ImageCode { get; set; }
        public double? UnitCost { get; set; }
        public double? FabricWeight { get; set; }
        public double? WashingCost { get; set; }
        public long? VersionId { get; set; }
        public double? WastagePercent { get; set; }
        public bool? IsWetProcessing { get; set; }
        public double? Acqty { get; set; }
        public double? Acrate { get; set; }
        public double? Acamount { get; set; }
        public double? Acvariance { get; set; }
    }
}
