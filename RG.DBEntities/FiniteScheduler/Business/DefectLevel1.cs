using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class DefectLevel1
    {
        public DefectLevel1()
        {
            DefectLevel2 = new HashSet<DefectLevel2>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public byte LevelNo { get; set; }

        public virtual ICollection<DefectLevel2> DefectLevel2 { get; set; }
    }
}
