using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetTrimsActual
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? ImageCodeId { get; set; }
        public string ImageCode { get; set; }
        public string ImageName { get; set; }
        public string UserCode { get; set; }
        public string VendorName { get; set; }
        public double? Consumption { get; set; }
        public double? WastageQuantity { get; set; }
        public double? WastagePercent { get; set; }
        public double? UnitCost { get; set; }
        public double? Gross { get; set; }
        public int? TrimConsumptionUnitId { get; set; }
        public int? GrossUnitId { get; set; }
        public int? VersionId { get; set; }
        public string TrimDescription { get; set; }
        public long? GrossCost { get; set; }
        public double? Acqty { get; set; }
        public double? Acrate { get; set; }
        public double? Acamount { get; set; }
        public double? Acvariance { get; set; }
    }
}
