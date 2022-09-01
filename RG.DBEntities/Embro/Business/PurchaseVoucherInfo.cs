using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class PurchaseVoucherInfo
    {
        [Key]
        public long VID { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        public int? AccountID { get; set; }
        public int? ItemID { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public int? StoreID { get; set; }
        public string RequisitionNumber { get; set; }
        public decimal? ConversionCost { get; set; }
        public string MaterialName { get; set; }
        public string QuantityUnit { get; set; }
        public int? Vindex { get; set; }
       

        public virtual Voucher Voucher { get; set; }
    }
}
