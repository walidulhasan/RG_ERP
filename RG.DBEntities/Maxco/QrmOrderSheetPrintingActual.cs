using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetPrintingActual
    {
        public int Id { get; set; }
        public int? TrimId { get; set; }
        public string ImageCode { get; set; }
        public int? Consumption { get; set; }
        public int? UnitCost { get; set; }
        public long? ImageId { get; set; }
        public string PrintImagePath { get; set; }
        public double? WastagePercent { get; set; }
        public long? VersionId { get; set; }
        public double? Amount { get; set; }
        public double? Acqty { get; set; }
        public double? Acrate { get; set; }
        public double? Acamount { get; set; }
        public double? Acvariance { get; set; }
    }
}
