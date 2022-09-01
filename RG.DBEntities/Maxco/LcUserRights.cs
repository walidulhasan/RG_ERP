using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcUserRights
    {
        public LcUserRights()
        {
            LcUserRightMap = new HashSet<LcUserRightMap>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LcUserRightMap> LcUserRightMap { get; set; }
    }
}
