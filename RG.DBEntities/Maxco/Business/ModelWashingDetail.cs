using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelWashingDetail
    {
        public int ID { get; set; }
        public int? WashingTypeID { get; set; }
        public double? WashingCost { get; set; }
        public long? StyleID { get; set; }
        public int? CollectionID { get; set; }
        public double? WetProcessCost { get; set; }
        public bool? IsWetProcess { get; set; }
        public bool? IsWashing { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public string WashingCode { get; set; }
        public string WetProcessingCode { get; set; }
        public int? WashingCodeID { get; set; }
        public double? FabricWeight { get; set; }
        public int? WetProcessingCodeID { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
