using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SampleAssortmentCounterSetup
    {
        public SampleAssortmentCounterSetup()
        {
            SampleAssortmentCounterQuantities = new HashSet<SampleAssortmentCounterQuantities>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SampleAssortmentCounterQuantities> SampleAssortmentCounterQuantities { get; set; }
    }
}
