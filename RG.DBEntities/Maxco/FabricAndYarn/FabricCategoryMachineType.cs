using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricCategoryMachineType
    {
        public int Id { get; set; }
        public int FabricCategoryId { get; set; }
        public byte MachineType { get; set; }

        public virtual FabricCategory_setup FabricCategory { get; set; }
        public virtual FabricMachineType_Setup MachineTypeNavigation { get; set; }
    }
}
