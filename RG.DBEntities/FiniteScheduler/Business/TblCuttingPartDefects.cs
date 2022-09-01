using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingPartDefects
    {
        public long Id { get; set; }
        public long? LotId { get; set; }
        public int? DefectId { get; set; }
        public decimal? DefectValue { get; set; }
        public decimal? Score { get; set; }
        public long? TransationId { get; set; }
        public long? Bundleno { get; set; }
        public long? Sizeid { get; set; }
        public long? Bundleqty { get; set; }
    }
}
