using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonImage_Setup
    {
        public ButtonImage_Setup()
        {
            ButtonSpecification = new HashSet<ButtonSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("ButtonMaterial_Setup")]
        public int MaterialID { get; set; }
        public int VendorID { get; set; }
        public string CodeToDisplay { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        [ForeignKey("TrimUnit_Setup")]
        public long? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeID { get; set; }
        public int? DesignTypeID { get; set; }
        public int? SizeID { get; set; }
        public int? InsertionID { get; set; }
        public int? PartHoleID { get; set; }
        public int? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }

        public virtual ButtonMaterial_Setup ButtonMaterial_Setup { get; set; }
        public virtual TrimUnit_Setup TrimUnit_Setup { get; set; }
        public virtual ICollection<ButtonSpecification> ButtonSpecification { get; set; }
    }
}
