using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class UnitDepartmentSetup
    {
        public UnitDepartmentSetup()
        {
            TrimIssueMaster = new HashSet<TrimIssueMaster>();
        }
        public int Id { get; set; }
        public int UnitDeptId { get; set; }
        public string UnitDeptDesc { get; set; }
        public int UnitLocationId { get; set; }

        public virtual UnitLocationSetup UnitLocation { get; set; }
        public virtual ICollection<TrimIssueMaster> TrimIssueMaster { get; set; }
    }
}
