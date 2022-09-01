using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintEmbroImage_Setup
    {
        public PrintEmbroImage_Setup()
        {
            //EmbroSpecification = new HashSet<EmbroSpecification>();
            //PrintEmbroSpecifications = new HashSet<PrintEmbroSpecifications>();
            PrintImageLayers_Setup = new HashSet<PrintImageLayers_Setup>();
        }

        public int ID { get; set; }
        public string EmbroImagePath { get; set; }
        public string EmbroGarmentImagePath { get; set; }
        public string EmbroCode { get; set; }
        public int? EmbroTypeID { get; set; }
        public int? EmbroNoOfLayers { get; set; }
        public string PrintImagePath { get; set; }
        public string PrintCode { get; set; }
        public int? PrintTypeID { get; set; }
        public bool? PrintIsTransfer { get; set; }
        public int? PrintMethodID { get; set; }
        public string PrintEmbroImagePath { get; set; }
        public int OrderStyleElementID { get; set; }
        public int PrintEmbroImageCategoryID { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public int? PrintStatus { get; set; }

       // public virtual EmbroTypeSetup EmbroType { get; set; }
        public virtual OrderStyleElement_Setup OrderStyleElement { get; set; }
       // public virtual PrintMethodSetup PrintMethod { get; set; }
        public virtual PrintingType_Setup PrintingType_Setup { get; set; }
        //public virtual ICollection<EmbroSpecification> EmbroSpecification { get; set; }
        //public virtual ICollection<PrintEmbroSpecifications> PrintEmbroSpecifications { get; set; }
       public virtual ICollection<PrintImageLayers_Setup> PrintImageLayers_Setup { get; set; }
    }
}
