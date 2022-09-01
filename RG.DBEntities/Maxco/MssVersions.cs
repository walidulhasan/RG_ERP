using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MssVersions
    {
        public long Id { get; set; }
        public long IosId { get; set; }
        public long VersionNo { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string IosXml { get; set; }
        public bool? IsOld { get; set; }
        public int Status { get; set; }
        public int DecisionStatus { get; set; }
    }
}
