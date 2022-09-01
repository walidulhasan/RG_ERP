using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblBundleBarcodeTrack
    {
        public decimal Sno { get; set; }
        public decimal? UserId { get; set; }
        public DateTime? LoginTime { get; set; }
        public decimal? OrderId { get; set; }
        public decimal? StyleId { get; set; }
        public decimal? ColorId { get; set; }
        public decimal? SizeId { get; set; }
        public string OrderName { get; set; }
        public string StyleName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public DateTime? TransTime { get; set; }
        public string TransName { get; set; }
        public string TransType { get; set; }
    }
}
