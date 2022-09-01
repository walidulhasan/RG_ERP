using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricCategoryToBeProcured
    {
        public int Id { get; set; }
        public int TypeId { get; set; }

        public virtual FsRequirementSheetFabricTypeSetup Type { get; set; }
    }
}
