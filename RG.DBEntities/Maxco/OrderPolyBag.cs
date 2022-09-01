using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPolyBag
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int AssortmentId { get; set; }
        public bool IsMasterReqd { get; set; }
        public short? NoOfSinglePieces { get; set; }
        public int VersionNo { get; set; }
    }
}
