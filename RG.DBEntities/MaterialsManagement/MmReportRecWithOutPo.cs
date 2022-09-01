using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReportRecWithOutPo
    {
        public long PspoId { get; set; }
        public int SupplierId { get; set; }
        public int OrderId { get; set; }
        public int ContactPerson { get; set; }
        public int Pono { get; set; }
        public DateTime Podate { get; set; }
        public string DeliveryChallanNo { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public string InvoiceNo { get; set; }
        public string VehicleNo { get; set; }
    }
}
