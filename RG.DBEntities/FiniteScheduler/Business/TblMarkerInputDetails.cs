using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerInputDetails
    {
        public long Id { get; set; }
        public long? InputId { get; set; }
        public long? Sizeid { get; set; }
        public string Sizename { get; set; }
        public decimal? Sizeqty { get; set; }
        public long? Bundleid { get; set; }
    }
}
