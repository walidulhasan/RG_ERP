using RG.DBEntities.FiniteScheduler.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class SfsProductionResourceType
    {
        public SfsProductionResourceType()
        {
            SfsProductionResourceSpecification = new HashSet<SfsProductionResourceSpecification>();
        }

        public int SfsPrtypeId { get; set; }
        public string Prdesc { get; set; }

        public virtual ICollection<SfsProductionResourceSpecification> SfsProductionResourceSpecification { get; set; }
    }
}
