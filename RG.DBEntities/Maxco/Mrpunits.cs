using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Mrpunits
    {
        public Mrpunits()
        {
            Mrpitem = new HashSet<Mrpitem>();
        }
        public int Id { get; set; }
        public int MrpunitsId { get; set; }
        public string UnitDesc { get; set; }
        public int UnitDatatype { get; set; }

        public virtual ICollection<Mrpitem> Mrpitem { get; set; }
    }
}
