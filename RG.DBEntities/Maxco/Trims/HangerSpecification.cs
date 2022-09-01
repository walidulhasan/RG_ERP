using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangerSpecification
    {
        public long ID { get; set; }
        public int ImageID { get; set; }
        public string Color { get; set; }
        public int ProcurementSourceID { get; set; }
        public long SelectedTrimID { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
        public string Comments { get; set; }
        public int TrimMeasurementScaleID { get; set; }
        public int TypeID { get; set; }
        public bool? IsSizeRing { get; set; }
        public int? InsertionID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }
    }
}
