using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TissuePaperPlacement
    {
        public int Id { get; set; }
        public int PlacementId { get; set; }
        public int TissuePaperId { get; set; }
    }
}
