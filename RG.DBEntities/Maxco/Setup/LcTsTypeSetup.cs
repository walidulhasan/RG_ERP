using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class LcTsTypeSetup
    {
        public LcTsTypeSetup()
        {
            LcTdTypeDependency = new HashSet<LcTdTypeDependency>();
        }
        public int Id { get; set; }
        public int LtsId { get; set; }
        public string LtsName { get; set; }

        public virtual ICollection<LcTdTypeDependency> LcTdTypeDependency { get; set; }
    }
}
