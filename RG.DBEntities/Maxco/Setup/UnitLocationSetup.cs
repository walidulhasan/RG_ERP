using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class UnitLocationSetup
    {
        public UnitLocationSetup()
        {
            UnitDepartmentSetup = new HashSet<UnitDepartmentSetup>();
        }
        public int Id { get; set; }
        public int UnitLocationId { get; set; }
        public string UnitLocationDesc { get; set; }

        public virtual ICollection<UnitDepartmentSetup> UnitDepartmentSetup { get; set; }
    }
}
