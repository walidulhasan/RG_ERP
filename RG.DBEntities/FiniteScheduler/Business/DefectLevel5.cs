using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectLevel5
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
        public string ConCatId { get; set; }
        public byte LevelNo { get; set; }

        public virtual DefectLevel4 Parent { get; set; }
    }
}
