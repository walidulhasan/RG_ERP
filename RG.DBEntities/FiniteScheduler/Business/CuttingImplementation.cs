using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingImplementation
    {
        public int Id { get; set; }
        public int ImplementationId { get; set; }
        public int TableId { get; set; }
    }
}
