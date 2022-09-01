using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class VoucherParameters
    {
        public int ID { get; set; }
        public int VoucherType { get; set; }
        public string EntryType { get; set; }
        public int AccountId { get; set; }
        public string Treatment { get; set; }
        public int? BusinessId { get; set; }

        public virtual VoucherType_setup VoucherTypeNavigation { get; set; }
    }
}
