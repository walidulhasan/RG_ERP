using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class VoucherLog
    {
        public long ID { get; set; }
        public long? VoucherID { get; set; }
        public string Comments { get; set; }
        public DateTime? CoomentsDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
