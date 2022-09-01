using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CmtFinanceMapping
    {
        public long Sno { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public long? AgencyId { get; set; }
        public long? WcId { get; set; }
        public int? Mrpitem { get; set; }
        public long? AccId { get; set; }
        public long? LocationId { get; set; }
        public long? CostCenterId { get; set; }
        public long? ActivityId { get; set; }
        public long? MaxcoAccont { get; set; }
    }
}
