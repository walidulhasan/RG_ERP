using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyAgencyIssuanceMaster
    {
        public long AgencyIssuanceId { get; set; }
        public long ChallanNo { get; set; }
        public int AgencyId { get; set; }
        public int UserId { get; set; }
        public long StyleId { get; set; }
        public byte[] Comments { get; set; }
        public long? AgencyChallanNo { get; set; }
    }
}
