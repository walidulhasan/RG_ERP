using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmOutGatePassMaster
    {
        public long OutGatePassId { get; set; }
        public long Rsmid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime OutGatePassDate { get; set; }
        public string PersonName { get; set; }
        public string VehicleNo { get; set; }
        public int? Poid { get; set; }
    }
}
