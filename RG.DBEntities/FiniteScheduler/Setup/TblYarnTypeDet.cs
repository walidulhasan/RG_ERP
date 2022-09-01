using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class TblYarnTypeDet
    {
        public int YtId { get; set; }
        public string YarnDes { get; set; }
        public byte[] YarnTypeCode { get; set; }
    }
}
