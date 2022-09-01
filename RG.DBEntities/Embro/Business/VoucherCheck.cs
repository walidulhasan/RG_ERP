using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class VoucherCheck
    {
        public int? UserId { get; set; }
        public int VoucherId { get; set; }
        public DateTime CheckDate { get; set; }
    }
}
