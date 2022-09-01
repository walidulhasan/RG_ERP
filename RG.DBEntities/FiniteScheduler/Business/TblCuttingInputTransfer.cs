using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingInputTransfer
    {
        public long CutInputTId { get; set; }
        public long? CInputId { get; set; }
        public long? MarkerId { get; set; }
        public long? Orderid { get; set; }
        public string Orderno { get; set; }
        public string OldOrderno { get; set; }
        public long? OldOrderid { get; set; }
        public long? MarkerShortId { get; set; }
        public DateTime? Creatondate { get; set; }
    }
}
