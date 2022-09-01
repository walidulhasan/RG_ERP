using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class DrawStringChordHolder
    {
        public int Id { get; set; }
        public int DrawStringId { get; set; }
        public int ChordHolderId { get; set; }
    }
}
