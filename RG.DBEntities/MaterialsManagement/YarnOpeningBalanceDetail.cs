using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOpeningBalanceDetail
    {
        [Key]
        public long ObDetailId { get; set; }
        public long? ObId { get; set; }
        public long? MrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public long? SupplierId { get; set; }
        public DateTime? MfgDate { get; set; }
        public long? BrandId { get; set; }
        public long? OrderId { get; set; }
        public decimal? Rate { get; set; }
        public long? UnitId { get; set; }
        public long? RateUnitId { get; set; }
        public decimal? TransactionQty { get; set; }
        public DateTime? DocumentDate { get; set; }
        public long? ConesPerProcurementUnit { get; set; }
        public long? StoreLocationId { get; set; }
        public string BatchNo { get; set; }
        public long? ProgramId { get; set; }
        public string LotNo { get; set; }
        public string OrderNo { get; set; }

        public virtual YarnOpeningBalanceMaster Ob { get; set; }
    }
}
