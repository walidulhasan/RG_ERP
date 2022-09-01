using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectLevel3
    {
        public DefectLevel3()
        {
            DefectLevel4 = new HashSet<DefectLevel4>();
        }

        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
        public string ConCatId { get; set; }
        public byte LevelNo { get; set; }

        public virtual DefectLevel2 Parent { get; set; }
        public virtual ICollection<DefectLevel4> DefectLevel4 { get; set; }
    }
}
