using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerRadioDetailes
    {
        public long Id { get; set; }
        public long? Stocktransationid { get; set; }
        public int? Sn { get; set; }
        public string Sizename { get; set; }
        public long? Sizeqty { get; set; }
    }
}
