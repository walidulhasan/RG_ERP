using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LabelSpecification
    {
        public LabelSpecification()
        {
            LabelColors = new HashSet<LabelColors>();
            LabelPlacementInstruction = new HashSet<LabelPlacementInstruction>();
        }

        public int ID { get; set; }
        public int LabelClassificationID { get; set; }
        public int? VarianceTypeID { get; set; }
        [ForeignKey("ProcurementSource_Setup")]
        public int ProcurementSourceID { get; set; }
        [ForeignKey("LabelImage_Setup")]
        public int ImageID { get; set; }
        [ForeignKey("TrimMeasurementScale_Setup")]
        public int? MeasurementScaleID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? UsePerPiece { get; set; }
        [ForeignKey("LabelMaterial_Setup")]
        public int MaterialID { get; set; }
        [ForeignKey("LabelAttachment_Setup")]
        public int AttachmentID { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
        [ForeignKey("SelectedTrim")]
        public long SelectedTrimID { get; set; }
        public string Comments { get; set; }
        public long? FabricSpecificationID { get; set; }
        public int LabelTypeID { get; set; }
        public bool? IsThreading { get; set; }
        public int InsertionID { get; set; }
        public string TechComments { get; set; }
        public long? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual LabelAttachment_Setup LabelAttachment_Setup { get; set; }
        public virtual LabelImage_Setup LabelImage_Setup { get; set; }
        public virtual LabelMaterial_Setup LabelMaterial_Setup { get; set; }
       public virtual TrimMeasurementScale_Setup MeasurementScale { get; set; }
       public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual ICollection<LabelColors> LabelColors { get; set; }
        public virtual ICollection<LabelPlacementInstruction> LabelPlacementInstruction { get; set; }
    }
}
