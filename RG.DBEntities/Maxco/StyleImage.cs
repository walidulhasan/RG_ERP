using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.Business;

namespace RG.DBEntities.Maxco
{
    public partial class StyleImage
    {
        public int Id { get; set; }
        public long StyleId { get; set; }
        public byte ImageTypeId { get; set; }
        public string Path { get; set; }

        public virtual ImageTypeSetup ImageType { get; set; }
        public virtual Style Style { get; set; }
    }
}
