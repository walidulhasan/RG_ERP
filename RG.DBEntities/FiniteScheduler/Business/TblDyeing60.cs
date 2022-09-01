using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeing60
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
        public decimal? ReqFabric { get; set; }
        public decimal? GreigeFabricQty { get; set; }
        public decimal? FinishedQty { get; set; }
        public decimal? FinishPercent { get; set; }
        public long? FinishRollQty { get; set; }
        public DateTime? Creationdate { get; set; }
        public decimal? TtlGreigeAgainstFinishedFabric { get; set; }
        public long? PantonId { get; set; }
        public string Pantonno { get; set; }
        public long? Styleid { get; set; }
        public string Composition { get; set; }
    }
}
