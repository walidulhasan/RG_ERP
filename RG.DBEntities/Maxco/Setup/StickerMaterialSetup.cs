using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class StickerMaterialSetup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StickerTypeId { get; set; }
    }
}
