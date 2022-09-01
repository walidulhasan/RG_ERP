using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class LocalSalesVoucherInfo
    {
        [Key]
        public long VID { get; set; }
        [ForeignKey("Voucher")]
        public decimal? VoucherID { get; set; }
        public decimal? AccountID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string DDNumber { get; set; }
        public DateTime? DODate { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? SalesTax { get; set; }
        public int? VIndex { get; set; }
        

        public virtual Voucher Voucher { get; set; }
    }
}
