using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectLevel2
    {
        public DefectLevel2()
        {
            DefectLevel3 = new HashSet<DefectLevel3>();
        }

        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
        public string ConCatId { get; set; }
        public byte LevelNo { get; set; }

        public virtual DefectLevel1 Parent { get; set; }
        public virtual ICollection<DefectLevel3> DefectLevel3 { get; set; }
    }
}
