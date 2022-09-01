using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Yarn_AllocationToKnitter
    {
        public int ID { get; set; }
        public long? YKNCID { get; set; }
        public string LotNo { get; set; }
        public string BatchNo { get; set; }
        public double? TransactionQuantity { get; set; }
        public int? UnitID { get; set; }
        public string Unit { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? AttributeInstanceID { get; set; }
        public int? LocationID { get; set; }
        public string Location { get; set; }
        public long? SupplierID { get; set; }
        public int? RateUnitID { get; set; }
        public double? Rate { get; set; }
        public double? MovingAverage { get; set; }
        public double? RateWrtbaseUnit { get; set; }
        public double? IssuedQty { get; set; }
        public int? IssuingUnitID { get; set; }
        public int? BrandID { get; set; }
        public int? Status { get; set; }
        public int? PackingID { get; set; }
        public string FabricGroup { get; set; }
        public string MasterShade { get; set; }
        public long? WOID { get; set; }
        public DateTime? MfgDate { get; set; }
        public long? YarnAttributeInstanceID { get; set; }
        public long? WoattributeInstanceID { get; set; }
    }
}
