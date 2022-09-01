using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerInputAccessInfo
    {
        public long Id { get; set; }
        public long? Userid { get; set; }
        public long? Lavelid { get; set; }
        public long? ModifyData { get; set; }
    }
}
