using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class FsRequirementSheetFabricTypeSetup
    {
        public FsRequirementSheetFabricTypeSetup()
        {
            FabricCategoryToBeProcured = new HashSet<FabricCategoryToBeProcured>();
        }
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FabricCategoryToBeProcured> FabricCategoryToBeProcured { get; set; }
    }
}
