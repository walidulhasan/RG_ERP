using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblCutting60
    {
        public long Id { get; set; }
        public string Buyername { get; set; }
        public long? BuyerId { get; set; }
        public long? CompanyId { get; set; }
        public string Companyname { get; set; }
        public long? OrderId { get; set; }
        public string OrderNo { get; set; }
        public string Color { get; set; }
        public long? OrderQty { get; set; }
        public decimal? FinishedQty { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? PantonId { get; set; }
        public string Pantonno { get; set; }
        public long? Styleid { get; set; }
        public long? CuttingPc { get; set; }
        public decimal? CuttingPercent { get; set; }
        public decimal? RequiredFebricKg { get; set; }
        public decimal? CuttingKg { get; set; }
        public decimal? CuttingDeliveredSewingKg { get; set; }
        public decimal? PerPcWeight { get; set; }
        public decimal? TtlCuttingWeight { get; set; }
        public decimal? TtlRejectPc { get; set; }
        public decimal? GrayQty { get; set; }
        public decimal? BookQty { get; set; }
    }
}
