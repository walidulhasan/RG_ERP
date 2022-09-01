using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
  public partial  class FabricCategory_setup
    {
        public FabricCategory_setup()
        {
            //FabricCategoryMachineType = new HashSet<FabricCategoryMachineType>();
            FabricType_Setup = new HashSet<FabricType_Setup>();
            //GreigeFabricCodeSetup = new HashSet<GreigeFabricCodeSetup>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        //public virtual ICollection<FabricCategoryMachineType> FabricCategoryMachineType { get; set; }
        public virtual ICollection<FabricType_Setup> FabricType_Setup { get; set; }
        //public virtual ICollection<GreigeFabricCodeSetup> GreigeFabricCodeSetup { get; set; }
    }
}
