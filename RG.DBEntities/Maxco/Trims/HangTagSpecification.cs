using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class HangTagSpecification
    {
        public HangTagSpecification()
        {
            //HangTagColors = new HashSet<HangTagColors>();
            HangTagPlacementInstruction = new HashSet<HangTagPlacementInstruction>();
            //HangTagSize = new HashSet<HangTagSize>();
        }

        public int ID { get; set; }
        public int HangTagTypeID { get; set; }
        public int HangTagClassificationID { get; set; }
        public int? VarianceTypeID { get; set; }
        [ForeignKey("ProcurementSource_Setup")]
        public int ProcurementSourceID { get; set; }
        [ForeignKey("HangTagImage_Setup")]
        public int ImageID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
         [ForeignKey("HangTagMaterial_Setup")]
        public int MaterialID { get; set; }
        
        public int AttachmentID { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
         [ForeignKey("SelectedTrim")]
        public long SelectedTrimID { get; set; }
        public string Comments { get; set; }
        public long? FabricSpecificationID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public int? HangTagCordMaterialID { get; set; }
        public bool IsThreading { get; set; }
        public int InsertionID { get; set; }
        public string TechComments { get; set; }
        public int? TrimStatus { get; set; }

       // public virtual HangTagAttachmentSetup HangTagAttachmentSetup { get; set; }
       // public virtual HangTagCordMaterialSetup HangTagCordMaterial { get; set; }
        public virtual HangTagImage_Setup HangTagImage_Setup { get; set; }
        public virtual HangTagMaterial_Setup HangTagMaterial_Setup { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        //public virtual ICollection<HangTagColors> HangTagColors { get; set; }
        public virtual ICollection<HangTagPlacementInstruction> HangTagPlacementInstruction { get; set; }
        //public virtual ICollection<HangTagSize> HangTagSize { get; set; }
    }
}
