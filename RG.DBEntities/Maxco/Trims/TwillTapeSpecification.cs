using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class TwillTapeSpecification
    {
        public TwillTapeSpecification()
        {
            TwillTapeColor = new HashSet<TwillTapeColor>();
            TwillTapePlacementInstruction = new HashSet<TwillTapePlacementInstruction>();
            //TwillTapeStripes = new HashSet<TwillTapeStripes>();
            //TwillTapeUse = new HashSet<TwillTapeUse>();
            //TwillTapeYarnSpecification = new HashSet<TwillTapeYarnSpecification>();
        }

        public long ID { get; set; }
        [ForeignKey("TwillTapeImage_Setup")]
        public int? ImageID { get; set; }
        
        [ForeignKey("TwillTapeWeave_Setup")]
        public int WeaveID { get; set; }
        [ForeignKey("TwillTapeWidth_Setup")] 
        public int WidthID { get; set; }
        public double? Shrinkage { get; set; }
        public int DyedID { get; set; }
        public int ProcurementSourceID { get; set; }
        public int VersionNo { get; set; }
        public string Comments { get; set; }
        public long SelectedTrimID { get; set; }
        public int Status { get; set; }
        public int? Consumption { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        public int ? WidthMeasurementScaleID { get; set; }
        public int InsertionID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual TwillTapeImage_Setup TwillTapeImage_Setup { get; set; }
        public virtual TwillTapeWeave_Setup TwillTapeWeave_Setup { get; set; }
        public virtual TwillTapeWidth_Setup TwillTapeWidth_Setup { get; set; }

        public virtual ICollection<TwillTapeColor> TwillTapeColor { get; set; }
        public virtual ICollection<TwillTapePlacementInstruction> TwillTapePlacementInstruction { get; set; }
        //public virtual ICollection<TwillTapeStripes> TwillTapeStripes { get; set; }
        //public virtual ICollection<TwillTapeUse> TwillTapeUse { get; set; }
        //public virtual ICollection<TwillTapeYarnSpecification> TwillTapeYarnSpecification { get; set; }
    }
}
