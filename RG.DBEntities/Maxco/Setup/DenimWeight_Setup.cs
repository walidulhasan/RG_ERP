using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class DenimWeight_Setup
    {
        public DenimWeight_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
    }
}
