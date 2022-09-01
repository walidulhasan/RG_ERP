using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyRejectingMaster
    {
        public long AgencyRejectingId { get; set; }
        public long ChallanNo { get; set; }
        public int AgencyId { get; set; }
        public int UserId { get; set; }
        public long StyleId { get; set; }
        public string Comments { get; set; }
    }
}
