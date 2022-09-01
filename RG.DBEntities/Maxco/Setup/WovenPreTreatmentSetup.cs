using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class WovenPreTreatmentSetup
    {
        public WovenPreTreatmentSetup()
        {
            WovenFabricPreTreatment = new HashSet<WovenFabricPreTreatment>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WovenFabricPreTreatment> WovenFabricPreTreatment { get; set; }
    }
}
