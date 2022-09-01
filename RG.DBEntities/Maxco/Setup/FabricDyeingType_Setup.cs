using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricDyeingType_Setup
    {
        public FabricDyeingType_Setup()
        {
            FabricSpecification = new HashSet<FabricSpecification>();
            GreigeFabricCodeSetup = new HashSet<GreigeFabricCode_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public string PageNavigation { get; set; }
        public int? FabricCategoryID { get; set; }

        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
        public virtual ICollection<GreigeFabricCode_Setup> GreigeFabricCodeSetup { get; set; }
    }
}
