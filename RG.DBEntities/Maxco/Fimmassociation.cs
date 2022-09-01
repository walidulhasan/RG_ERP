using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Fimmassociation
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public int ValuationClassId { get; set; }

        public virtual Mrpitem MrpitemCodeNavigation { get; set; }
    }
}
