using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricWetProcessSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? FabricCategoryId { get; set; }
        public double? Smv { get; set; }
        public bool? IsDeleted { get; set; }
        public string Code { get; set; }
    }
}
