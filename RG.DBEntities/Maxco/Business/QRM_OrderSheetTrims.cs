using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_OrderSheetTrims
    {
        public int ID { get; set; }
        public int MRPitemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? ImageCodeID { get; set; }
        public string ImageCode { get; set; }
        public string ImageName { get; set; }
        public string UserCode { get; set; }
        public string VendorName { get; set; }
        public double? Consumption { get; set; }
        public double? WastageQuantity { get; set; }
        public double? WastagePercent { get; set; }
        public double? UnitCost { get; set; }
        public double? Gross { get; set; }
        public int? TrimConsumptionUnitID { get; set; }
        public int? GrossUnitID { get; set; }
        [ForeignKey("QRM_OrderSheetVersions")]
        public int? VersionID { get; set; }
        public string TrimDescription { get; set; }
        public string ColorCode { get; set; }
        public int? ColorSetID { get; set; }
        public string ColorName { get; set; }

        public virtual QRM_OrderSheetVersions QRM_OrderSheetVersions { get; set; }
    }
}
