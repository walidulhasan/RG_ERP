using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcPrPonumberRanges
    {
        public int Id { get; set; }
        public int LprId { get; set; }
        public int LpoId { get; set; }
        public int LprPorangestart { get; set; }
        public int LprPorangeend { get; set; }
    }
}
