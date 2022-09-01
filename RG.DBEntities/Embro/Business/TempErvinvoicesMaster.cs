using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public partial class TempErvinvoicesMaster
    {
        public int TempMasterInvoiceId { get; set; }
        public string TempMasterInvoiceNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
