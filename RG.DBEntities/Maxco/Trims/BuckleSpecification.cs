using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class BuckleSpecification
    {
        public BuckleSpecification()
        {
            BuckleColor = new HashSet<BuckleColor>();
            BucklePlacementInstruction = new HashSet<BucklePlacementInstruction>();
        }
        [Key]
        public long ID { get; set; }
        public int? UsePerPiece { get; set; }
        public bool IsMetalFinish { get; set; }
        public int VersionNo { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }
        public int ProcurementSourceID { get; set; }
        public int SizeID { get; set; }
        public int ImageID { get; set; }
        public long SelectedTrimID { get; set; }
        public int InsertionID { get; set; }
        public int? MeasurementScaleID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        //public virtual TrimMeasurementScaleSetup MeasurementScale { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
        public virtual BuckleSize_Setup BuckleSize_Setup { get; set; }
        public virtual ICollection<BuckleColor> BuckleColor { get; set; }
        public virtual ICollection<BucklePlacementInstruction> BucklePlacementInstruction { get; set; }
    }
}
