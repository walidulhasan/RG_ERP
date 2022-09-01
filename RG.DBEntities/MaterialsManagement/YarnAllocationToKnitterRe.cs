using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnAllocationToKnitterRe
    {
        public int Id { get; set; }
        public DateTime? TransactionDateNew { get; set; }
        public int? IdOld { get; set; }
        public long? Ykncid { get; set; }
        public string LotNo { get; set; }
        public string BatchNo { get; set; }
        public double? TransactionQuantity { get; set; }
        public int? UnitId { get; set; }
        public string Unit { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int? LocationId { get; set; }
        public string Location { get; set; }
        public long? SupplierId { get; set; }
        public int? RateUnitId { get; set; }
        public double? Rate { get; set; }
        public double? MovingAverage { get; set; }
        public double? RateWrtbaseUnit { get; set; }
        public double? IssuedQty { get; set; }
        public int? IssuingUnitId { get; set; }
        public int? BrandId { get; set; }
        public int? Status { get; set; }
        public int? PackingId { get; set; }
        public string FabricGroup { get; set; }
        public string MasterShade { get; set; }
        public long? Woid { get; set; }
        public DateTime? MfgDate { get; set; }
        public long? YarnAttributeInstanceId { get; set; }
        public long? WoattributeInstanceId { get; set; }
    }
}
