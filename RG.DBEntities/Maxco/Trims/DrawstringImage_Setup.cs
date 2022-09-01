using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
   public partial class DrawstringImage_Setup
    {
        public DrawstringImage_Setup()
        {
            DrawstringSpecification = new HashSet<DrawstringSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        public string CodeToDisplay { get; set; }
        public int VendorID { get; set; }
        [ForeignKey("DrawstringType_Setup")]
        public int TypeID { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        [ForeignKey("TrimUnit_Setup")]
        public long? TrimUnitID { get; set; }
        [ForeignKey("DrawstringMaterial_Setup")]
        public int? MaterialID { get; set; }
        public long? TrimID { get; set; }
        public bool? IsElasticated { get; set; }
        public int? DyedID { get; set; }
        public int? NoOfPlies { get; set; }
        public bool? IsTipping { get; set; }
        public long? UserID { get; set; }
        public bool? IsValidate { get; set; }
        public int? DesignTypeID { get; set; }
        public string Code { get; set; }
        public double? Fob { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? Clrtotal { get; set; }
        public string UserCode { get; set; }

        public virtual DrawstringMaterial_Setup DrawstringMaterial_Setup { get; set; }
        public virtual TrimUnit_Setup TrimUnit { get; set; }
        public virtual DrawstringType_Setup DrawstringType_Setup { get; set; }
        public virtual ICollection<DrawstringSpecification> DrawstringSpecification { get; set; }
    }
}
