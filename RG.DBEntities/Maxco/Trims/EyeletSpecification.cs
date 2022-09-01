using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class EyeletSpecification
    {
        //public EyeletSpecification()
        //{
        //    EyeletColor = new HashSet<EyeletColor>();
        //    EyeletPlacementInstruction = new HashSet<EyeletPlacementInstruction>();
        //}

        public int ID { get; set; }
        public int ImageID { get; set; }
        public bool IsMetalFinish { get; set; }
        public int SizeID { get; set; }
        public int? UsePerPiece { get; set; }
        public int InsertionID { get; set; }
        public int VersionNo { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimID { get; set; }
        public int Status { get; set; }
        public int ProcurementSourceID { get; set; }
        public int? DyedID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual EyeletImage_Setup EyeletImage_Setup { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual EyeletSize_Setup EyeletSize_Setup { get; set; }
        //public virtual ICollection<EyeletColor> EyeletColor { get; set; }
        //public virtual ICollection<EyeletPlacementInstruction> EyeletPlacementInstruction { get; set; }
    }
}
