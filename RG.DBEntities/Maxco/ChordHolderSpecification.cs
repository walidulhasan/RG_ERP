using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class ChordHolderSpecification
    {
        public ChordHolderSpecification()
        {
            ChordholderColor = new HashSet<ChordholderColor>();
            ChordholderPlacementInstruction = new HashSet<ChordholderPlacementInstruction>();
        }

        public int Id { get; set; }
        public short ImageId { get; set; }
        public byte DesignId { get; set; }
        public byte? SizeId { get; set; }
        public byte? UsePerPiece { get; set; }
        public byte InsertionId { get; set; }
        public int ProcurementSourceId { get; set; }
        public long? SelectedTrimId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public bool IsMetalFinish { get; set; }
        public string Comments { get; set; }
        public int? MeasurementScaleId { get; set; }
        public string TechComments { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ChordholderDesignSetup Design { get; set; }
        public virtual ChordholderImageSetup Image { get; set; }
        public virtual TrimMeasurementScale_Setup MeasurementScale { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual ChordholderSizeSetup Size { get; set; }
        public virtual ICollection<ChordholderColor> ChordholderColor { get; set; }
        public virtual ICollection<ChordholderPlacementInstruction> ChordholderPlacementInstruction { get; set; }
    }
}
