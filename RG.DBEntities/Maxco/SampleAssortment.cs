using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleAssortment
    {
        public SampleAssortment()
        {
            GarmentAssortment = new HashSet<GarmentAssortment>();
            SampleAssortmentCounterQuantities = new HashSet<SampleAssortmentCounterQuantities>();
        }

        public int Id { get; set; }
        public long StyleId { get; set; }

        public virtual Style Style { get; set; }
        public virtual ICollection<GarmentAssortment> GarmentAssortment { get; set; }
        public virtual ICollection<SampleAssortmentCounterQuantities> SampleAssortmentCounterQuantities { get; set; }
    }
}
