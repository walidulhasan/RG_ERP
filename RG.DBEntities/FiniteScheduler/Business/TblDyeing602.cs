using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeing602
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public long? Buyerid { get; set; }
        public string Buyername { get; set; }
        public string Companyname { get; set; }
        public long? CompanyId { get; set; }
        public string StyleDescription { get; set; }
        public long? Styleid { get; set; }
        public decimal? OrderQty { get; set; }
        public string FabricComposition { get; set; }
        public decimal? RequiredFebricKg { get; set; }
        public decimal? ReqGrayQty { get; set; }
        public decimal? ApprovePercentage { get; set; }
        public decimal? DyeingQty { get; set; }
        public decimal? FinishQty { get; set; }
        public decimal? WestagePercent { get; set; }
        public decimal? SaveFabric { get; set; }
        public decimal? LossFabric { get; set; }
        public decimal? ProducePercent { get; set; }
        public DateTime? Creatiodate { get; set; }
    }
}
