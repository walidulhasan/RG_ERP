using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class KnittingYarnRate1
    {
        public int Id { get; set; }
        public int KnittingRateId { get; set; }
        public int YarnCompositionId { get; set; }
        public int YarnQualityId { get; set; }
        public int YarnCountId { get; set; }
        public int? PantoneNo { get; set; }
    }
}
