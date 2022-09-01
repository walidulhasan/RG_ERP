using RG.DBEntities.Maxco.FabricAndYarn;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PrintingColor
    {
        public int Id { get; set; }

        public int ObjectId { get; set; }
        public long ColorSetId { get; set; }
        public string TrimColor { get; set; }
        public int MatchId { get; set; }

        public virtual PrintingSpecification Object { get; set; }
    }
}
