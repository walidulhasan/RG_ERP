using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmInvoiceMaster
    {
        public MmInvoiceMaster()
        {
            MmInvoiceDetail = new HashSet<MmInvoiceDetail>();
        }
        [Key]
        public long Iid { get; set; }
        public string InvoiceNo { get; set; }
        public string CinvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int SupplierId { get; set; }
        public double TotalAmount { get; set; }
        public double Difference { get; set; }
        public DateTime CinvoiceDate { get; set; }

        public virtual ICollection<MmInvoiceDetail> MmInvoiceDetail { get; set; }
    }
}
