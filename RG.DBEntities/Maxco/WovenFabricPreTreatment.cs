using System;
using System.Collections.Generic;

using RG.DBEntities.Maxco.Setup;

namespace RG.DBEntities.Maxco
{
    public partial class WovenFabricPreTreatment
    {
        public int Id { get; set; }
        public int PreTreatmentId { get; set; }
        public int FabricSpecificationId { get; set; }

        public virtual WovenPreTreatmentSetup PreTreatment { get; set; }
    }
}
