using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblGreigeWastage
    {
        public long Id { get; set; }
        public string FabricComposition { get; set; }
        public long? From { get; set; }
        public long? To { get; set; }
        public int? Percentage { get; set; }
    }
}
