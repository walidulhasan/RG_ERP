using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Payroll_Main
    {
        public decimal InvoiceID { get; set; }
        public string InvoiceSystemID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string PONum { get; set; }
        public decimal SupplierID { get; set; }
        public decimal CompanyID { get; set; }
        public decimal PreparedBy { get; set; }
        public DateTime PrepareDate { get; set; }
        public string Status { get; set; }
        public decimal? ExDtyRate { get; set; }
        public int InvoiceType { get; set; }
        public decimal? CurrencyRate { get; set; }
        public decimal? AdvAdjusted { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string LcAcceptenceNo { get; set; }
        public decimal? InvoiceAmount { get; set; }
    }
}
