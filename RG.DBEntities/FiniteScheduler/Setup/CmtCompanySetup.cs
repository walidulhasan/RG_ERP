using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class CmtCompanySetup
    {
        public long Sno { get; set; }
        public int? MrpitemCode { get; set; }
        public long? CreditorAccId { get; set; }
        public long? DebitorAccId { get; set; }
        public long? WorkCenter { get; set; }
    }
}
