using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class TblIndWorkorderMaster
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public long? SupplierId { get; set; }
        public string ServiceName { get; set; }
        public string Quotation { get; set; }
        public long? PaymentMode { get; set; }
        public long? PaymentTerms { get; set; }
        public long? Currency { get; set; }
        public decimal? ExRate { get; set; }
        public long? UserId { get; set; }
        public long? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? WorkorderDate { get; set; }
        public DateTime? WorkorderEndDate { get; set; }
        public DateTime? QuotationDate { get; set; }
        public string Body { get; set; }
        public string Inword { get; set; }
        public string Subject { get; set; }
        public string Information { get; set; }
        public string Note { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Ait { get; set; }
        public string ContuctPerson { get; set; }
        public string MobileNo { get; set; }
    }
}
