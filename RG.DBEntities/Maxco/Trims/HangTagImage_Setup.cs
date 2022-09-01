using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class HangTagImage_Setup
    {
        public HangTagImage_Setup()
        {
            HangTagSpecification = new HashSet<HangTagSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public int VendorID { get; set; }
        public int? TypeID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public int? IsPriceInsert { get; set; }
        public long? TrimUnitID { get; set; }
        public double? Price { get; set; }
        public long? TrimID { get; set; }
        public int? ClassificationID { get; set; }
        public int? MaterialID { get; set; }
        public int? DesignID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public string CodeToDisplay { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRtotal { get; set; }
        public string UserCode { get; set; }

        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual HangTagType_Setup Type { get; set; }
        public virtual ICollection<HangTagSpecification> HangTagSpecification { get; set; }
    }
}
