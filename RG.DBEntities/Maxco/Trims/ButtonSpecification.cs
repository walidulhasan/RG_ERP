using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonSpecification
    {
        public ButtonSpecification()
        {
            ButtonColor = new HashSet<ButtonColor>();
            ButtonPlacementInstruction = new HashSet<ButtonPlacementInstruction>();
        }

        public long ID { get; set; }
        [ForeignKey("ButtonImage_Setup")]
        public int ImageID { get; set; }
        public bool? IsMetalFinish { get; set; }
        [ForeignKey("ButtonPartHole_Setup")]
        public int PartHoleID { get; set; }
        public bool IsThreading { get; set; }
        [ForeignKey("ButtonSize_Setup")]
        public int SizeID { get; set; }
        [ForeignKey("ButtonHoleArrangement_Setup")]
        public int? HoleArrangementID { get; set; }
        public byte? UsePerPiece { get; set; }
        public byte InsertionID { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimID { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        [ForeignKey("ProcurementSource_Setup")]
        public int ProcurementSourceID { get; set; }
        public bool? IsFabricColor { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ButtonHoleArrangement_Setup ButtonHoleArrangement_Setup { get; set; }
        public virtual ButtonImage_Setup ButtonImage_Setup { get; set; }
        public virtual ButtonPartHole_Setup ButtonPartHole_Setup { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual ButtonSize_Setup ButtonSize_Setup { get; set; }
        public virtual ICollection<ButtonColor> ButtonColor { get; set; }
        public virtual ICollection<ButtonPlacementInstruction> ButtonPlacementInstruction { get; set; }
    }
}
