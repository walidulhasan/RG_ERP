using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ElasticImage_Setup
    {
        public int ID { get; set; }
        public string CodeToDisplay { get; set; }
        public string ImagePath { get; set; }
        public int VendorID { get; set; }
        public int TypeID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public int? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public int? WidthID { get; set; }
        public int? WidthMeasurementScaleID { get; set; }
        public int? StringID { get; set; }
        public int? FinishID { get; set; }
        public long? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeID { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }
    }
}
