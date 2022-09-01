using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class StylePatternPiece
    {
        public long JobTicketNo { get; set; }
        public int JobId { get; set; }
        public long StyleId { get; set; }
        public string Description { get; set; }
        public byte? FabricTrimId { get; set; }
        public int FabricSpecificationId { get; set; }
        public string BodyPart { get; set; }
        public string PatternPiece { get; set; }
    }
}
