using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WoPermanentReceivingMaster
    {
        public long PermRecMid { get; set; }
        public DateTime? PermRecDate { get; set; }
        public long Mimid { get; set; }
        public int Status { get; set; }
        public string PermRecNo { get; set; }
        public long? Woid { get; set; }
        public int? Flag { get; set; }
        public long? CompanyId { get; set; }
        public long? BusinessId { get; set; }
    }
}
