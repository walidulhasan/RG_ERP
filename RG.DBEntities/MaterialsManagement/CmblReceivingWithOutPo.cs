using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblReceivingWithOutPo
    {
        [Key]
        public int RecWithOutPoid { get; set; }
        public DateTime DocumentDate { get; set; }
        public long SupplierId { get; set; }
        public string Pono { get; set; }
        public DateTime Podate { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string ContactPerson { get; set; }
        public string InvoiceNo { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryChallanDate { get; set; }
        public int UserId { get; set; }
        public long CompanyId { get; set; }
        public int RecWithOutPono { get; set; }
        public string Deleted { get; set; }
        public long? YarnKncontractId { get; set; }
    }
}
