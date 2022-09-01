using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class DrawstringSpecification
    {
        public DrawstringSpecification()
        {
            DrawstringColor = new HashSet<DrawstringColor>();
            DrawstringPlacementInstruction = new HashSet<DrawstringPlacementInstruction>();
            DrawstringUse = new HashSet<DrawstringUse>();
        }

        public int ID { get; set; }
        [ForeignKey("DrawstringImage_Setup")]
        public int ImageID { get; set; }
        [ForeignKey("DrawstringMaterial_Setup")]
        public int MaterialID { get; set; }
        public bool IsElasticated { get; set; }
        public int InsertionID { get; set; }
        public int NoOfPlies { get; set; }
        public bool IsTipping { get; set; }
        public string Comments { get; set; }
        public int Status { get; set; }
        public int VersionNo { get; set; }
        public long? SelectedTrimID { get; set; }
        public int ProcurementSourceID { get; set; }
        public double? Consumption { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        [ForeignKey("DrawStringDyeing_Setup")]
        public int? DyedID { get; set; }
        public bool? IsChordHolder { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual DrawStringDyeing_Setup Dyed { get; set; }
        public virtual DrawstringImage_Setup DrawstringImage_Setup { get; set; }
        public virtual DrawstringMaterial_Setup DrawstringMaterial_Setup { get; set; }
        public virtual ICollection<DrawstringColor> DrawstringColor { get; set; }
        public virtual ICollection<DrawstringPlacementInstruction> DrawstringPlacementInstruction { get; set; }
        public virtual ICollection<DrawstringUse> DrawstringUse { get; set; }
    }
}

    
