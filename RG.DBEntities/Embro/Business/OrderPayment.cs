using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class OrderPayment
    {
        public long OrderId { get; set; }
        public long VoucherId { get; set; }
        public long? Esvid { get; set; }
    }
}
