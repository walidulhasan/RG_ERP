using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsProductionResourceRelations
    {
        public int Id { get; set; }
        public int? ParentSfsPrsid { get; set; }
        public int ChildSfsPrsid { get; set; }
    }
}
