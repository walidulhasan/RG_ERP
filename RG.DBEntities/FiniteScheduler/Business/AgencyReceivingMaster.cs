using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyReceivingMaster
    {
        public long AgencyReceivingId { get; set; }
        public long ChallanNo { get; set; }
        public long AgencyId { get; set; }
        public int UserId { get; set; }
        public long StyleId { get; set; }
        public string Comments { get; set; }
        public int? IsBarCode { get; set; }
    }
}
