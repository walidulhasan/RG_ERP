using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPullerColor
    {
        public int Id { get; set; }
        public int? ObjectId { get; set; }
        public string TrimColor { get; set; }
        public long? ColorSetId { get; set; }
        public byte? MatchId { get; set; }
    }
}
