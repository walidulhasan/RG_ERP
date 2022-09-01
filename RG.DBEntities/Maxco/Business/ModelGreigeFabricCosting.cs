using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelGreigeFabricCosting
    {
        public ModelGreigeFabricCosting()
        {
            ModelGriegeFabric_YarnsCosting = new HashSet<ModelGriegeFabric_YarnsCosting>();
  
        }

        public int ID { get; set; }
        public int? FabricCompositionID { get; set; }
        public int? FabricTypeID { get; set; }
        public int? FabricQualityID { get; set; }
        public int? MachineTypeID { get; set; }
        public int? GSM { get; set; }
        public int? FabricID { get; set; }
        public double? KnittingWastagePer { get; set; }
        public double? GreigeFabricCost { get; set; }
        public double? TotalYarnRate { get; set; }
        public long? StyleID { get; set; }
        public int? CollectionID { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public double? KnittingRate { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
        public virtual ICollection<ModelGriegeFabric_YarnsCosting> ModelGriegeFabric_YarnsCosting { get; set; }
    }
}
