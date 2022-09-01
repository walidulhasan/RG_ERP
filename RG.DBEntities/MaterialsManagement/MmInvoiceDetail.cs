using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmInvoiceDetail
    {
        [Key]
        public long Idid { get; set; }
        public long Iid { get; set; }
        public long PermRecMid { get; set; }
        public double Amount { get; set; }
        public double Gst { get; set; }

        public virtual MmInvoiceMaster I { get; set; }
    }
}
