using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class PolyBagImage_Setup
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
        public long? TrimID { get; set; }
        public bool? IsPrinting { get; set; }
        public int PrintingTypeID { get; set; }
        public int ThicknessID { get; set; }
        public int MaterialID { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public int? UserID { get; set; }
        public bool? IsFlap { get; set; }
        public bool? IsHangerCut { get; set; }
        public bool? IsOpeningHangerCut { get; set; }
        public int? FlapTypeID { get; set; }
        public int? AdhesiveTypeID { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRtotal { get; set; }
        public int? DesignID { get; set; }
        public int? GussetID { get; set; }
        public bool? IsAirHole { get; set; }
        public string UserCode { get; set; }
        public int? VendorID { get; set; }
    }
}
