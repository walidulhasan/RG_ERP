using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipSpecification
    {
        public ZipSpecification()
        {
            ZipColor = new HashSet<ZipColor>();
            ZipLength = new HashSet<ZipLength>();
            ZipPlacementInstruction = new HashSet<ZipPlacementInstruction>();
            ZipPullerSpecification = new HashSet<ZipPullerSpecification>();
        }

        public int Id { get; set; }
        public short SliderImageId { get; set; }
        public int? SliderTypeId { get; set; }
        public bool IsSliderMetalFinish { get; set; }
        public byte MaterialId { get; set; }
        public bool? IsTeethMetalFinish { get; set; }
        public byte OpenCloseId { get; set; }
        public double Number { get; set; }
        public bool IsMale { get; set; }
        public byte? UsePerPiece { get; set; }
        public int ProcurementSourceId { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public byte TapeMaterialId { get; set; }
        public bool? IsPuller { get; set; }
        public bool? IsStud { get; set; }
        public int? TrimMeasurementScaleId { get; set; }
        public byte InsertionId { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeId { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ZipMaterialSetup Material { get; set; }
        public virtual ZipNumberSetup NumberNavigation { get; set; }
        public virtual ZipOpenCloseSetup OpenClose { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource { get; set; }
        public virtual ZipSliderImageSetup SliderImage { get; set; }
        public virtual ZipSliderTypeSetup SliderType { get; set; }
        public virtual ZipTapeMaterialSetup TapeMaterial { get; set; }
        public virtual TrimMeasurementScale_Setup TrimMeasurementScale { get; set; }
        public virtual ICollection<ZipColor> ZipColor { get; set; }
        public virtual ICollection<ZipLength> ZipLength { get; set; }
        public virtual ICollection<ZipPlacementInstruction> ZipPlacementInstruction { get; set; }
        public virtual ICollection<ZipPullerSpecification> ZipPullerSpecification { get; set; }
    }
}
