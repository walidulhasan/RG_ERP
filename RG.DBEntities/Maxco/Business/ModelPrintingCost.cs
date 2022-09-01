using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelPrintingCost
    {
        public int ID { get; set; }
        public int TrimID { get; set; }
        public string ImageCode { get; set; }
        public double Consumption { get; set; }
        public double UnitCost { get; set; }
        public long StyleID { get; set; }
        public int CollectionID { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public int? ImageID { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
