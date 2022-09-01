using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblOperations
    {
        public long Operationid { get; set; }
        public string Operationname { get; set; }
        public long? Gtid { get; set; }
    }
}
