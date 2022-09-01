using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsRejectionSerialDetails
    {
        public long BundleId { get; set; }
        public long PatternPieceId { get; set; }
        public int SerialNo { get; set; }
    }
}
