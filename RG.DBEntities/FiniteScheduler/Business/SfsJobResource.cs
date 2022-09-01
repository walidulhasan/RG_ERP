using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsJobResource
    {
        public long JobId { get; set; }
        public long ResourceId { get; set; }

        public virtual SfsJob Job { get; set; }
    }
}
