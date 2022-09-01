using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Invoice_Main
    {
        public APM_Invoice_Main()
        {
            APM_Invoice_Detail = new HashSet<APM_Invoice_Detail>();
        }
        [Key]
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

        public virtual ICollection<APM_Invoice_Detail> APM_Invoice_Detail { get; set; }
    }
}
