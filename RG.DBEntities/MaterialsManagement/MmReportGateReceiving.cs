using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReportGateReceiving
    {
        public string Grno { get; set; }
        public int Grid { get; set; }
        public int Grdid { get; set; }
        public int ObjectId { get; set; }
        public int Poid { get; set; }
        public long AttributeInstanceId { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public double? Quantity { get; set; }
    }
}
