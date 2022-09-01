using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class LaceSpecification
    {
        public LaceSpecification()
        {
            LaceColor = new HashSet<LaceColor>();
            LacePlacementInstruction = new HashSet<LacePlacementInstruction>();
        }

        public int ID { get; set; }
        [ForeignKey("LaceImage_Setup")]
        
        public int ImageID { get; set; }
         [ForeignKey("LaceWidth_Setup")]
        public int WidthID { get; set; }
        [ForeignKey("LaceMaterial_Setup")]
        public int MaterialID { get; set; }
        [ForeignKey("ProcurementSource_Setup")]
        public int ProcurementSourceID { get; set; }
        public int VersionNo { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }
         [ForeignKey("SelectedTrim")]
        public long SelectedTrimID { get; set; }
        public double? Consumption { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        public int? WidthMeasurementScaleID { get; set; }
        [ForeignKey("LaceDyeing_Setup")]
        public int? DyeingID { get; set; }
        public int? test { get; set; }
        public int? InsertionID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual LaceDyeing_Setup LaceDyeing_Setup { get; set; }
        public virtual LaceImage_Setup LaceImage_Setup { get; set; }
       public virtual LaceMaterial_Setup LaceMaterial_Setup { get; set; }
        public virtual ProcurementSource_Setup ProcurementSource_Setup { get; set; }
        public virtual SelectedTrim SelectedTrim { get; set; }
       // public virtual TrimMeasurementScale_Setup TrimMeasurementScale { get; set; }
       public virtual LaceWidth_Setup LaceWidth_Setup { get; set; }
        public virtual ICollection<LaceColor> LaceColor { get; set; }
        public virtual ICollection<LacePlacementInstruction> LacePlacementInstruction { get; set; }
    }
}
