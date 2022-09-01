using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblAgencyTransMaster
    {
        public long RefNo { get; set; }
        public long ChallanNo { get; set; }
        public int AgencyId { get; set; }
        public decimal MrpitemCode { get; set; }
        public bool? IsGarment { get; set; }
        public int? UserId { get; set; }
    }
}
