using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class LocalSalesCustomerInfo
    {
        [Key,Column(Order=0)]
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }
        [Key, Column(Order = 1)]
        public int CustomerID { get; set; }
        public string CustomerDesc { get; set; }
        public string SalesTaxNumber { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
