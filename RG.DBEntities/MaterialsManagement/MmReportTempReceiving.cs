using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReportTempReceiving
    {
        public long Mtrmid { get; set; }
        public long Grid { get; set; }
        public string Tgrno { get; set; }
        public DateTime TempRecDate { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public long Poid { get; set; }
        public string Grno { get; set; }
    }
}
