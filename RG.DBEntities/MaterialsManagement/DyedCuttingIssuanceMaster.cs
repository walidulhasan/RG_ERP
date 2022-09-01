using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DyedCuttingIssuanceMaster
    {
        public long IssuanceId { get; set; }
        public DateTime IssuanceDate { get; set; }
        public string IssuanceNo { get; set; }
        public int? UserId { get; set; }
    }
}
