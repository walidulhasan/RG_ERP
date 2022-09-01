using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class SubVoucherTypeSetup
    {
        public int Id { get; set; }
        public int VoucherTypeId { get; set; }
        public string SubVoucherType { get; set; }
        public string Initials { get; set; }
        public int? SubVoucherTypeId { get; set; }

        public virtual VoucherType_setup VoucherType { get; set; }
    }
}
