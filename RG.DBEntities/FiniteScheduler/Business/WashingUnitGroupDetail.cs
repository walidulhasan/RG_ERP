using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingUnitGroupDetail
    {
        public int Id { get; set; }
        public int UnitGroupMasterId { get; set; }
        public int UnitId { get; set; }
        public bool Deleted { get; set; }
    }
}
