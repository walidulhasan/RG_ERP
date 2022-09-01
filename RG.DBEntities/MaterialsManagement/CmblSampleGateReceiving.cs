using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSampleGateReceiving
    {
        [Key]
        public int SampleRecId { get; set; }
        public DateTime DocumentDate { get; set; }
        public long SupplierId { get; set; }
        public long SampleId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Deleted { get; set; }
        public long? SampleRecNo { get; set; }
        public string DeliveryChallano { get; set; }
        public DateTime? DeliveryChallanDate { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNumber { get; set; }
    }
}
