using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblMarkerInputInfo
    {
        public long CInputId { get; set; }
        public long? MarkerId { get; set; }
        public long? Orderid { get; set; }
        public string Orderno { get; set; }
        public long? Colorid { get; set; }
        public string Colorname { get; set; }
        public long? Buyerid { get; set; }
        public string Buyername { get; set; }
        public string Composition { get; set; }
        public string Ftype { get; set; }
        public long? Lineid { get; set; }
        public string Linename { get; set; }
        public long? Userid { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Styleid { get; set; }
        public string Stylename { get; set; }
        public long? Location { get; set; }
        public long? MarkerShortId { get; set; }
        public long? Cutoffid { get; set; }
        public string OldOrderno { get; set; }
        public long? OldOrderid { get; set; }
        public long? Bundleid { get; set; }
    }
}
