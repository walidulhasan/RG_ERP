using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricBrandSetup
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public short MillId { get; set; }
        public string BrandDescription { get; set; }
    }
}
