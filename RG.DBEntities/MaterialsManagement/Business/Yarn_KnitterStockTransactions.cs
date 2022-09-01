using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
   public class Yarn_KnitterStockTransactions
    {
        [Key]
        public long KnitterStockTrnsID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? MRPItemCode { get; set; }
        public long? AttributeInstanceID { get; set; }
        public long? SupplierID { get; set; }
        public DateTime? MfgDate { get; set; }
        public int? BrandID { get; set; }
        public int? PackagingID { get; set; }
        public int? ConesPerProcurementUnit { get; set; }
        public int? UnitID { get; set; }
        public decimal? rate { get; set; }
        public long? rateUnitID { get; set; }
        public decimal? MovingAverage { get; set; }
        public decimal? TransactionQty { get; set; }
        public string BatchNo { get; set; }
        public int? ProgramTypeID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public string LotNo { get; set; }
        public decimal? RateWRTBaseUnit { get; set; }
        public long? KnittingContractID { get; set; }
        public long? IssuanceToKnitterID { get; set; }
        public string BagName { get; set; }
    }
}
