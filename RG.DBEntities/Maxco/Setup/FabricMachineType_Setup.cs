using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class FabricMachineType_Setup
    {
        public FabricMachineType_Setup()
        {
            FabricCategoryMachineType = new HashSet<FabricCategoryMachineType>();
            FabricSpecification = new HashSet<FabricSpecification>();
            GreigeFabricCodeSetup = new HashSet<GreigeFabricCode_Setup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricCategoryMachineType> FabricCategoryMachineType { get; set; }
        public virtual ICollection<FabricSpecification> FabricSpecification { get; set; }
        public virtual ICollection<GreigeFabricCode_Setup> GreigeFabricCodeSetup { get; set; }
    }
}
