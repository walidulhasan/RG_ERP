using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VwMinMaxStitDate
    {
        public long StyleId { get; set; }
        public long? StDateVal { get; set; }
        public long? EdDateVal { get; set; }
        public long? ExpWashDt { get; set; }
    }
}
