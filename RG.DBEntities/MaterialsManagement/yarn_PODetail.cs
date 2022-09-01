using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class yarn_PODetail
    {
        [Key]
        public long Yarn_PODetailID { get; set; }
        public long Yarn_POID { get; set; }
        public int MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public decimal OrderQTY { get; set; }
        public int UnitID { get; set; }
        public decimal Rate { get; set; }
        public int RateUnitID { get; set; }
        public decimal GST { get; set; }
        public int BrandID { get; set; }
        public int PackagingID { get; set; }
        public int ConesPerProcurementUnit { get; set; }
        public int NoOfDeliveries { get; set; }
        public decimal? AmountWithGST { get; set; }
        public decimal? AmountWithOutGST { get; set; }
        public decimal? BalanceQTY { get; set; }
        public decimal? tempBalanceQty { get; set; }
        public int? Cartons { get; set; }
        public decimal? CurrencyRate { get; set; }
    }
}
