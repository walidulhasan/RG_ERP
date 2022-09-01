 
using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
 

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BeadSpecification
    {
        public BeadSpecification()
        {
            BeadColor = new HashSet<BeadColor>();
            BeadPlacementInstruction = new HashSet<BeadPlacementInstruction>();
        }

        public long ID { get; set; }
        public int ImageID { get; set; }
        public bool? IsMetalFinish { get; set; }
        public int? UsePerPiece { get; set; }
        public int SizeID { get; set; }
        public int AttachmentID { get; set; }
        public int InsertionID { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimID { get; set; }
        public int VersionNo { get; set; }
        public int Status { get; set; }
        public bool? IsFabricColor { get; set; }
        public int ProcurementSourceID { get; set; }
        public bool? IsThreading { get; set; }
        public string TechComments { get; set; }
        public bool? IsValid { get; set; }
        public int? DesignTypeID { get; set; }
        public int? HoleArrangementID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual BeadAttachment_Setup BeadAttachment_Setup { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual BeadSize_Setup BeadSize_Setup { get; set; }
        public virtual ICollection<BeadColor> BeadColor { get; set; }
        public virtual ICollection<BeadPlacementInstruction> BeadPlacementInstruction { get; set; }
    }
}
