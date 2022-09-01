using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class MaterialReceiptMaster
    {[Key]
        public int Mrmid { get; set; }
        public int? Mpmid { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? VendorId { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliverPerson { get; set; }
        public string Pono { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }

        public virtual MaterialPomaster Mpm { get; set; }
    }
}
