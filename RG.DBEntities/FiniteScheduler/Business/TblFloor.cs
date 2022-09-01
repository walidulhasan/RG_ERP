using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblFloor
    {
        public long FloorId { get; set; }
        public string FloorName { get; set; }
        public long? LocationId { get; set; }
        public int? Active { get; set; }
    }
}
