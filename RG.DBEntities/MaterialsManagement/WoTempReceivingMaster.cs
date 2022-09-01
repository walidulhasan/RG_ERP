using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoTempReceivingMaster
    {
        public long Wotrmid { get; set; }
        public int Grid { get; set; }
        public string Tgrno { get; set; }
        public DateTime? TempRecDate { get; set; }
        public int Woid { get; set; }
        public int? InspectedStatus { get; set; }
        public int? Flag { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
