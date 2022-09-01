using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblAgencyTransDetail
    {
        public long TransId { get; set; }
        public long RefNo { get; set; }
        public long PieceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long AttributeInstanceId { get; set; }
    }
}
