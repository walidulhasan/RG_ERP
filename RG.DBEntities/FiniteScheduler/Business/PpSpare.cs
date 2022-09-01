using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PpSpare
    {
        public long? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public long FabricTypeId { get; set; }
        public string FabricType { get; set; }
    }
}
