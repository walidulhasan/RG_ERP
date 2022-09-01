using System;
using System.Collections.Generic;
 
using RG.DBEntities.Maxco.Setup;
namespace RG.DBEntities.Maxco.Trims
{
    public partial class BuckleImage_Setup
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
        public int MaterialID { get; set; }
        public int VendorID { get; set; }
        public string CodeToDisplay { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public long? TrimUnitID { get; set; }
        public int? TrimID { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeID { get; set; }
        public int? SizeID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public int? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignPatternID { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }

        public virtual BuckleMaterial_Setup BuckleMaterial_Setup { get; set; }
      //  public virtual TrimUnitSetup TrimUnit { get; set; }
    }
}
