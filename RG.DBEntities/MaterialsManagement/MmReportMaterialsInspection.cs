using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReportMaterialsInspection
    {
        public int? Mtrmid { get; set; }
        public int? Grid { get; set; }
        public int? Tgrno { get; set; }
        public DateTime? TempRecDate { get; set; }
        public string DeliveryChallan { get; set; }
        public string DeliveryPerson { get; set; }
        public string VehicleNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? Poid { get; set; }
        public int? Grno { get; set; }
        public int? Mimid { get; set; }
        public int? Minsno { get; set; }
        public DateTime? InspectionDate { get; set; }
    }
}
