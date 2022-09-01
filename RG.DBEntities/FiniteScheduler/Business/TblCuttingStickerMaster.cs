using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingStickerMaster
    {
        public long Cutidno { get; set; }
        public long? Challanid { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? OrderCutno { get; set; }
        public long? Orderid { get; set; }
        public long? Countryid { get; set; }
    }
}
