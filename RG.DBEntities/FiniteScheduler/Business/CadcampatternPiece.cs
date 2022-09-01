using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CadcampatternPiece
    {
        public int CadcampatternPieceId { get; set; }
        public int CadcambodyPartId { get; set; }
        public int QrmpatternPieceId { get; set; }

        public virtual CadcambodyPart CadcambodyPart { get; set; }
    }
}
