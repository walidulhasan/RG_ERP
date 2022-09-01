using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsManualOperations
    {
        public int Id { get; set; }
        public int GeManualOperationId { get; set; }
        public string OperationName { get; set; }
        public short NoOfPersons { get; set; }
    }
}
