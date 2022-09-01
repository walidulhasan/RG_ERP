using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class StickerImageSetup
    {
        public int Id { get; set; }
        public string PicturePath { get; set; }
        public int StickerTypeId { get; set; }
    }
}
