using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class APM_Invoice_Status
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
