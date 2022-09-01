using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Setup
{
    public partial class VoucherConfigurationSetup
    {
        public long ID { get; set; }
        public int? VoucherType { get; set; }
        public string Parameter { get; set; }
        public string Nature { get; set; }
        public string SelectionMode { get; set; }
        public long? AccountID { get; set; }
        public long? BusinessID { get; set; }
    }
}
