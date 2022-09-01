using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblProblem
    {
        public long Problemid { get; set; }
        public string Problemname { get; set; }
        public long? Gtid { get; set; }
        public long? Operationid { get; set; }
    }
}
