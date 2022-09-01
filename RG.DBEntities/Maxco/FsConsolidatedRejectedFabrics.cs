using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsConsolidatedRejectedFabrics
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string ConsolidatedRejectedXml { get; set; }
    }
}
