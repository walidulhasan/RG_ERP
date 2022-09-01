using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class ModelTrimCost
    {
        public int ID { get; set; }
        public int TrimID { get; set; }
        public string ImageCode { get; set; }
        public int? ImageCodeID { get; set; }
        public double Consumption { get; set; }
        public double UnitCost { get; set; }
        public long StyleID { get; set; }
        public int CollectionID { get; set; }
        public int? VendorID { get; set; }
        public string VendorName { get; set; }
        public int? TrimUnitID { get; set; }
        [ForeignKey("ModelCosting")]
        public int? VersionID { get; set; }
        public double? FOB { get; set; }
        public double? Frieght { get; set; }
        public double? Duty { get; set; }
        public double? ClearanceTotal { get; set; }
        public double? ZipSize { get; set; }
        public string UserCode { get; set; }
        public int? ProcurementSourceID { get; set; }
        public int? MaterialID { get; set; }
        public int? CountID { get; set; }
        public int? NoOfPlies { get; set; }
        public virtual ModelCosting ModelCosting { get; set; }
    }
}
