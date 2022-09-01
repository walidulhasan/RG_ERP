using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class PrintingLayers
    {
        public int ID { get; set; }
        [ForeignKey("PrintingSpecification")]
        public int ObjectID { get; set; }
        public string PantoneNo { get; set; }
        [ForeignKey("PrintingType_Setup")]
        public int PrintTypeID { get; set; }
        [ForeignKey("PrintColorType_Setup")]
        public int PrintColorTypeID { get; set; }
        public string Material { get; set; }
        public int? PrintMaterialSizeID { get; set; }
        public int? FlockMaterialID { get; set; }
        public bool? IsTransfer { get; set; }
        public double? Thickness { get; set; }
        public int PalletTypeID { get; set; }
        public int? SeqNo { get; set; }
        public int? PrintImageColorID { get; set; }
        public int? ImageID { get; set; }
        public int? ColorSetID { get; set; }
        public virtual PrintingSpecification PrintingSpecification { get; set; }
        //public virtual FlockMaterialSetup FlockMaterial { get; set; }
         public virtual PrintColorType_Setup PrintColorType_Setup { get; set; }
        //public virtual PrintMaterialSizeSetup PrintMaterialSize { get; set; }
         public virtual PrintingType_Setup PrintingType_Setup { get; set; }
    }
}
