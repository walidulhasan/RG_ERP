using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class FsQualityAttributeSetup
    {
        public long Id { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double? ToleranceStart { get; set; }
        public double? ToleranceEnd { get; set; }
    }
}
