using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelGriegeFabric_YarnsCosting
    {
        public int ID { get; set; }
        [ForeignKey("ModelGreigeFabricCosting")]
        public int? GreigeFabricID { get; set; }
        public int? YarnCompositionID { get; set; }
        public int? YarnQualityID { get; set; }
        public int? YarnCountID { get; set; }
        public int? YarnUtilizationPer { get; set; }
        public double? YarnRate { get; set; }
         public virtual ModelGreigeFabricCosting ModelGreigeFabricCosting { get; set; }
    }
}
