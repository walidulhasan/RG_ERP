using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyStyleChallanStatus
    {
        public int AgencyId { get; set; }
        public int StyleId { get; set; }
        public int AgencyChallanNo { get; set; }
        public bool? FlowChallanRecStatus { get; set; }
    }
}
