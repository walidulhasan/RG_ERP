using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class StyleInfo
    {
        public long StyleId { get; set; }
        public int FabricTrimSelectedId { get; set; }
        public byte? FabricTrimId { get; set; }
        public string FabricTrim { get; set; }
        public int FabricSpecificationId { get; set; }
        public long FscolorId { get; set; }
        public string PantonNo { get; set; }
        public int? Ppsid { get; set; }
        public string AssignedStyleNo { get; set; }
    }
}
