using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonGateReceiving
    {
        [Key]
        public long Grid { get; set; }
        public long ContractId { get; set; }
        public string DeliveryChallanNo { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long CompanyId { get; set; }
        public int? TempStatus { get; set; }
        public string Grno { get; set; }
        public int? Deleted { get; set; }
        public int? UserId { get; set; }
        public double? FreightCharges { get; set; }
        public double? LoadedVehicleWeight { get; set; }
    }
}
