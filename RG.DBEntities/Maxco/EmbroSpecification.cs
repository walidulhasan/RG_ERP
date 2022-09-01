using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Business;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroSpecification
    {
        public EmbroSpecification()
        {
            EmbroColor = new HashSet<EmbroColor>();
            EmbroLayers = new HashSet<EmbroLayers>();
            EmbroPlacementInstruction = new HashSet<EmbroPlacementInstruction>();
            EmbroSizes = new HashSet<EmbroSizes>();
        }

        public int Id { get; set; }
        public int ImageId { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public byte VariantId { get; set; }
        public byte InsertionId { get; set; }
        public int StyleId { get; set; }
        public string Comments { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public int SelectedElementId { get; set; }
        public int? FabricSpecificationId { get; set; }
        public int? MeasurementScaleId { get; set; }
        public bool IsFusing { get; set; }
        public bool? IsThreading { get; set; }
        public int? DescriptionType { get; set; }
        public double? PerPieceTime { get; set; }
        public int? NoOfApplique { get; set; }
        public int? FrameNameId { get; set; }
        public double? FrameLayingTime { get; set; }
        public double? AppliqueLayingTime { get; set; }
        public bool? IsPatch { get; set; }

        public virtual PrintEmbroImage_Setup Image { get; set; }
        public virtual StyleElementMeasurementScale MeasurementScale { get; set; }
        public virtual SelectedElement SelectedElement { get; set; }
        public virtual EmbroVariantSetup Variant { get; set; }
        public virtual ICollection<EmbroColor> EmbroColor { get; set; }
        public virtual ICollection<EmbroLayers> EmbroLayers { get; set; }
        public virtual ICollection<EmbroPlacementInstruction> EmbroPlacementInstruction { get; set; }
        public virtual ICollection<EmbroSizes> EmbroSizes { get; set; }
    }
}
