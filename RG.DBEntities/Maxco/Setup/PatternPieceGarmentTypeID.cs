using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PatternPieceGarmentTypeID
    {
        public long ID { get; set; }
        public int PatternPieceSetupID { get; set; }
        public int? GarmentTypeID { get; set; }
    }
}
