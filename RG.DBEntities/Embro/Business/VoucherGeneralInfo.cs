using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Business
{
    public partial class VoucherGeneralInfo
    {
        public int ID { get; set; }
        [ForeignKey("Voucher")]
        public decimal VoucherID { get; set; }        
        public int AccountID { get; set; }
        public string Description { get; set; }
        public string Billno { get; set; }
        public DateTime? Billdate { get; set; }
        public string RefNo { get; set; }
        public decimal? discount { get; set; }
        public decimal? InTax { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Net { get; set; }
        public string Comments { get; set; }
        public string Currency { get; set; }
        public decimal? ConversionRate { get; set; }
        public string SupplierDONumber { get; set; }
        public DateTime? PODate { get; set; }
        public DateTime? GRNDate { get; set; }
        public DateTime? DCDate { get; set; }
        public decimal? InvoiceEffect { get; set; }
        public int? Vindex { get; set; }
        public decimal? ExciseDuty { get; set; }
        public string LCNumber { get; set; }
        public long? LCID { get; set; }
        public long? BankAccID { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
