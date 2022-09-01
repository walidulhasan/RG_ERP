using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class EyeletImage_Setup
    {
        public EyeletImage_Setup()
        {
            EyeletSpecification = new HashSet<EyeletSpecification>();
        }

        public int ID { get; set; }
        public string ImagePath { get; set; }
        public int MaterialID { get; set; }
        public int VendorID { get; set; }
        public string CodeToDisplay { get; set; }
        public DateTime CreationDate { get; set; }
        public int? CollectionID { get; set; }
        public double? Price { get; set; }
        public int? IsPriceInsert { get; set; }
        public int? TrimUnitID { get; set; }
        public long? TrimID { get; set; }
        public bool? IsMetalFinish { get; set; }
        public long? MetalFinishTypeID { get; set; }
        public int? SizeID { get; set; }
        public bool? IsValidate { get; set; }
        public string UserID { get; set; }
        public int? DesignTypeID { get; set; }
        public string Code { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? CLRTotal { get; set; }
        public string UserCode { get; set; }

        public virtual ICollection<EyeletSpecification> EyeletSpecification { get; set; }
    }
}
