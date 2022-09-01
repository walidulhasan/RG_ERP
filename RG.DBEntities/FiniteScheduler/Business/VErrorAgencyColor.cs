using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VErrorAgencyColor
    {
        public long ChallanNo { get; set; }
        public long FlowAtt { get; set; }
        public long AgencyAtt { get; set; }
        public long FlowSize { get; set; }
        public long AgencySize { get; set; }
        public long FlowColor { get; set; }
        public long AgencyColor { get; set; }
        public long? FlowFabricColor { get; set; }
        public int? FlowPiece { get; set; }
        public long AgencyPiece { get; set; }
        public int AgencyId { get; set; }
        public DateTime TransDate { get; set; }
    }
}
