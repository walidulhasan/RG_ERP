using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPreShipmentInvoice
    {
        public BciPreShipmentInvoice()
        {
            BciPreShipmentInvoiceDetail = new HashSet<BciPreShipmentInvoiceDetail>();
        }

        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<BciPreShipmentInvoiceDetail> BciPreShipmentInvoiceDetail { get; set; }
    }
}
