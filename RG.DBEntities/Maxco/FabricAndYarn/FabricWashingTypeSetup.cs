using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricWashingTypeSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FabricCategoryId { get; set; }
        public bool? Isdeleted { get; set; }
        public string Code { get; set; }
    }
}
