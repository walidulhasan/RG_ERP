using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoGateReceiving
    {
        public int Grid { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Woid { get; set; }
        public string Grno { get; set; }
        public int Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }
        public int? Flag { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
