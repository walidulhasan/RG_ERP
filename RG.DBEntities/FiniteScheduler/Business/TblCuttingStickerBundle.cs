using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingStickerBundle
    {
        public long Bundleid { get; set; }
        public long? Cutidno { get; set; }
        public long? Bundlesrno { get; set; }
        public long? Minstickerno { get; set; }
        public long? Maxstickerno { get; set; }
        public long? Sizeid { get; set; }
        public long? Challanid { get; set; }
        public string Sizename { get; set; }
        public long? Countryid { get; set; }
        public string Rfidno { get; set; }
        public DateTime? Creationdate { get; set; }
        public int? BundleStatus { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? Mbundleid { get; set; }
    }
}
