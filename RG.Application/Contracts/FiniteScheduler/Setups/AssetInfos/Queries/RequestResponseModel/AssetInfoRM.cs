using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Mappings;
using RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetInfos.Queries.RequestResponseModel
{
    public class AssetInfoRM
    {
        
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public string Code { get; set; }
        public int? AssetLoactionID { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetAssignedType { get; set; }
        public string TypeName { get; set; }
        public int AssetSubTypeID { get; set; }
        public string SubTypeName { get; set; }
        public int CodeSerial { get; set; }
        public string BrandName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public bool IsFreeAsset { get; set; }
        public int CompanyID { get; set; }
        public bool IsReturnable { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime AssetDepriciationHistoryDateFrom { get; set; }
        public  virtual List<SelectListItem> DDLAssetTypeName { get; set; }
        public  virtual List<SelectListItem> DDLAssetSubType { get; set; }
    }
}
