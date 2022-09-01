using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectLevel4
    {
        public DefectLevel4()
        {
            DefectLevel5 = new HashSet<DefectLevel5>();
        }

        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
        public string ConCatId { get; set; }
        public byte LevelNo { get; set; }

        public virtual DefectLevel3 Parent { get; set; }
        public virtual ICollection<DefectLevel5> DefectLevel5 { get; set; }
    }
}
