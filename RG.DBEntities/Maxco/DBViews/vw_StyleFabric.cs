using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.DBViews
{
    public class vw_StyleFabric
    {
        public long StyleID { get; set; }
        public long? OrderID { get; set; }
        public string StyleName { get; set; }
        public int? Status { get; set; }
        public int? ProcurementStatus { get; set; }
        public int? CapturingStatus { get; set; }
        public bool GrossStatus { get; set; }
        public int SelectedElementStatus { get; set; }
        public int? SelectedElementID { get; set; }
        public int? FabricTrimID { get; set; }
        public string FabricTrim { get; set; }
        public int? FabricTrimSelectedStatus { get; set; }
        public long? FabricSpecificationID { get; set; }
        public int? QualityID { get; set; }
        public string FabricQuality { get; set; }
        public int? FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public int? GSM { get; set; }
        public int? MachineTypeID { get; set; }
        public string MachineType { get; set; }
        public int? GaugeID { get; set; }
        public int? DyeingID { get; set; }
        public int? ShrinkageWidth { get; set; }
        public int? ShrinkageLength { get; set; }
        public long? FabricParentID { get; set; }
        public int? FabricTrimSelectedID { get; set; }
        public bool? IsSpandex { get; set; }
        public int? Spandex { get; set; }
        public double? FinishedWidth { get; set; }
        public string FabricComposition { get; set; }
        public int? FabricCategoryID { get; set; }
        public int? UserSelectedUnitID { get; set; }
        public int? ProcurementUnitID { get; set; }
    }
}
