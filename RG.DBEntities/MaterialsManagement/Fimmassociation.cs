using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class Fimmassociation
    {
        public int Id { get; set; }
        public int MrpitemCode { get; set; }
        public int ValuationClassId { get; set; }
    }
}
