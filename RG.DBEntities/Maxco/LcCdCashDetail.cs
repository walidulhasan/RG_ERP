using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCdCashDetail
    {
        public int Id { get; set; }
        public int LcdId { get; set; }
        public int LcmId { get; set; }
        public int? LcdPonoId { get; set; }
        public int? LmpId { get; set; }
        public string LciVendorpino { get; set; }
    }
}
