using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricFinishingProcessSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? FabricCategoryId { get; set; }
    }
}
