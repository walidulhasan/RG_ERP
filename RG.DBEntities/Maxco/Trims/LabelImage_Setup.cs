using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelImage_Setup
    {
        public LabelImage_Setup()
        {
            LabelSpecification = new HashSet<LabelSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public int VendorID { get; set; }
        [ForeignKey("LabelType_Setup")]
        public int TypeID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        [ForeignKey("TrimUnit_Setup")]
        public long? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public int? LabelClassificationID { get; set; }
        public int? MaterialID { get; set; }
        public int? DesignID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public long? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeID { get; set; }
        public string CodeToDisplay { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }

         public virtual TrimUnit_Setup TrimUnit { get; set; }//TrimUnit_Setup
        public virtual LabelType_Setup LabelType_Setup { get; set; }
        public virtual ICollection<LabelSpecification> LabelSpecification { get; set; }
    }
}
