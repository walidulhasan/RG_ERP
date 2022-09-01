using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class LcBsBuyinghouseSetup
    {
        public int Id { get; set; }
        public short LbsId { get; set; }
        public string LbsCode { get; set; }
        public string LbsName { get; set; }
        public string LbsDesc { get; set; }
        public string LbsPhoneno { get; set; }
        public string LbsContactperson { get; set; }
        public byte LbsIsactive { get; set; }
    }
}
