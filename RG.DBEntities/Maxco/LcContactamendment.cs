using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcContactamendment
    {
        public long Id { get; set; }
        public long LomId { get; set; }
        public long? AmndUserid { get; set; }
        public DateTime? Date { get; set; }
        public decimal? AmndValue { get; set; }
        public string AmndQty { get; set; }
        public decimal? AmndBtbper { get; set; }
        public decimal? AmndYarnper { get; set; }
        public decimal? AmndKnitper { get; set; }
        public decimal? AmndFabricdyeper { get; set; }
        public decimal? AmndDyesper { get; set; }
        public decimal? AmndPrintper { get; set; }
        public decimal? AmndTrimper { get; set; }
        public decimal? AmndOtherper { get; set; }
    }
}
