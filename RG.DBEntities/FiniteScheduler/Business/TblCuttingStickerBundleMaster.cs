using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingStickerBundleMaster
    {
        public long Bundlemid { get; set; }
        public long? Sizeid { get; set; }
        public string Sizename { get; set; }
        public int? Startno { get; set; }
        public int? Endno { get; set; }
        public long? Challanid { get; set; }
        public int? Bundlesrno { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? MainBundleid { get; set; }
        public long? Rollid { get; set; }
        public long? Cuttingno { get; set; }
        public string Rollcode { get; set; }
        public int? SizeRatio { get; set; }
    }
}
