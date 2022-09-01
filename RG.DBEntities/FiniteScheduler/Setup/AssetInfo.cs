using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class AssetInfo : DefaultTableProperties
    {
        public AssetInfo()
        {
            AssetLocation = new List<AssetLocation>();
        }
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetAssignedType { get; set; }
        public string Code { get; set; }
        
        public string BrandName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal ValueAfterDeprication { get; set; }
        public int CompanyID { get; set; }
        public bool IsReturnable { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string LCNo { get; set; }
        public decimal? DepriciationPercent { get; set; }
        public DateTime? DapricationDateFrom { get; set; }
        public DateTime? DapricationDateTo { get; set; }
        public int FunctionalStatusID { get; set; }
        public decimal? Capacity { get; set; }
        public int? CapacityUnitID { get; set; }
        public string ModelNo { get; set; }
        public virtual List<AssetLocation> AssetLocation { get; set; }
    }
}
