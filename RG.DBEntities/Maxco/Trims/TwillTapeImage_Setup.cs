using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeImage_Setup
    {
        public TwillTapeImage_Setup()
        {
             TwillTapeSpecification = new HashSet<TwillTapeSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("TwillTapeMaterial_Setup")]
        public int MaterialID { get; set; }
        public string CodeToDisplay { get; set; }
        public int VendorID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
         [ForeignKey("TrimUnit_Setup")]  
        public long? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public int? WeaveID { get; set; }
        public int? WidthID { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        public int? DyedID { get; set; }
        public long? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeID { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }

        public virtual TwillTapeMaterial_Setup TwillTapeMaterial_Setup { get; set; }
        public virtual TrimUnit_Setup TrimUnit_Setup { get; set; }
        public virtual ICollection<TwillTapeSpecification> TwillTapeSpecification { get; set; }
    }
}
