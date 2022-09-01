using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCuttingSticker
    {
        public long Id { get; set; }
        public long? Challanid { get; set; }
        public long? Rollid { get; set; }
        public long? Sizeid { get; set; }
        public string Sizename { get; set; }
        public string Rollno { get; set; }
        public long? Stickerno { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Srno { get; set; }
        public long? Cuttingno { get; set; }
        public long? Countryid { get; set; }
        public long? Rfidno { get; set; }
        public long? Bundleid { get; set; }
        public long? BundleidM { get; set; }
    }
}
