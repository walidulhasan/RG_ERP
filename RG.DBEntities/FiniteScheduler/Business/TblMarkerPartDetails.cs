using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerPartDetails
    {
        public long Cmpdid { get; set; }
        public long? Cmpid { get; set; }
        public string PartName { get; set; }
        public int? Sr { get; set; }
        public int? Active { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}
