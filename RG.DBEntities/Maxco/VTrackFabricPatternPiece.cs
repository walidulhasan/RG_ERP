using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VTrackFabricPatternPiece
    {
        public int Id { get; set; }
        public string BodyPart { get; set; }
        public string PatternPiece { get; set; }
        public string Description { get; set; }
        public int TrimId { get; set; }
        public long StyleId { get; set; }
        public int PatternPieceId { get; set; }
        public string ColorName { get; set; }
    }
}
