using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoMaterialInspectionMaster
    {
        public long Mimid { get; set; }
        public long Wotrmid { get; set; }
        public string Minsno { get; set; }
        public DateTime? InspectionDate { get; set; }
        public int Woid { get; set; }
        public int Grnstatus { get; set; }
        public int? OutGatePassStatus { get; set; }
        public int? Flag { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
