using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ElasticSpecification
    {
        public ElasticSpecification()
        {
            ElasticPlacementInstruction = new HashSet<ElasticPlacementInstruction>();
            ElasticColor = new HashSet<ElasticColor>();
          //  ElasticUse = new HashSet<ElasticUse>();
            
        }

        public int ID { get; set; }
        public int? ImageID { get; set; }
        public int TypeID { get; set; }
        public int WidthID { get; set; }
        public int StringID { get; set; }
        public int FinishID { get; set; }
        public string Comments { get; set; }
        public int VersionNo { get; set; }
        public string Color { get; set; }
        public int Status { get; set; }
        public int SelectedTrimID { get; set; }
        public double? Consumption { get; set; }
        public int? TrimMeasurementScaleID { get; set; }
        public int? ProcurementSourceID { get; set; }
        public int? WidthMeasurementScaleID { get; set; }
        public bool? IsDrawString { get; set; }
        public int InsertionID { get; set; }
        public string TechComments { get; set; }
        public int? DesignTypeID { get; set; }
        public int? TrimStatus { get; set; }

        public virtual ICollection<ElasticPlacementInstruction> ElasticPlacementInstruction { get; set; }
       // public virtual ICollection<ElasticUse> ElasticUse { get; set; }
        public virtual ICollection<ElasticColor> ElasticColor { get; set; }
        
    }
}
