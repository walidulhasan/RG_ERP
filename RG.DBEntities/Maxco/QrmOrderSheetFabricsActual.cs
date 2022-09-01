using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmOrderSheetFabricsActual
    {
        public int Id { get; set; }
        public int? MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? FabricTypeId { get; set; }
        public int? FabricQualityId { get; set; }
        public string FabricComposition { get; set; }
        public int? DyeingId { get; set; }
        public int? Gsm { get; set; }
        public double FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public int VersionId { get; set; }
        public double? RequiredQty { get; set; }
        public double? UnitConsumption { get; set; }
        public double? Skucost { get; set; }
        public int? SizeId { get; set; }
        public string SizeDescription { get; set; }
        public double? DyeingRate { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public string ColorName { get; set; }
        public int? ProcurementUnitId { get; set; }
        public int? UnitId { get; set; }
        public string Unit { get; set; }
        public int? WastagePercent { get; set; }
        public double? Acqty { get; set; }
        public double? Acrate { get; set; }
        public double? Acamount { get; set; }
        public double? Acvariance { get; set; }
    }
}
