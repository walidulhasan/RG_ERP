using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsColorSet
    {
        public long Id { get; set; }
        public long ReqId { get; set; }
        public long ColorSetId { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string Htmlcode { get; set; }
        public string VariationColor { get; set; }
        public string VariationColorHtmlcode { get; set; }
    }
}
