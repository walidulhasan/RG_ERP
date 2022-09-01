using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelYarnCosting
    {
        public int ID { get; set; }
        public long? YarnID { get; set; }
        public int? UnitID { get; set; }
        public double? Rate { get; set; }
        public int? YarnDyeingID { get; set; }
        public int? YarnQualityID { get; set; }
        public int? YarnCompositionID { get; set; }
        public int? YarnCountID { get; set; }
        public int? IsDyed { get; set; }
        public string ColorType { get; set; }
        public string PantoneNo { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public int? FabricYarnVendorID { get; set; }
        public int? FabricYarnVendorColorID { get; set; }
        public long? StyleID { get; set; }
        public int? CollectionID { get; set; }
        public int? SupplierID { get; set; }

        public virtual ModelCosting ModelCosting { get; set; }
    }
}
