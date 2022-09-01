using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricRnDorder
    {
        public int Id { get; set; }
        public int? StyleId { get; set; }
        public int? FabricRndSheetId { get; set; }
    }
}
