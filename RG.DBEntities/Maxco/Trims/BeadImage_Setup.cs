using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BeadImage_Setup
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string CodeToDisplay { get; set; }
        public int VendorID { get; set; }
        public int MaterialID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public int? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeID { get; set; }
        public int? DesignTypeID { get; set; }
        public int? SizeID { get; set; }
        public int? AttachmentID { get; set; }
        public bool? IsValidate { get; set; }
        public int? UserID { get; set; }
        public int? PartHoleID { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }
    }
}
