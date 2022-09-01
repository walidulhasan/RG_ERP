using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel
{
    public class GetAllAssetAndRelationalInfoRM
    {
        public int? AssetID { get; set; }
        public int? BuildingID { get; set; }
        public int? FloorID { get; set; }
        public int? DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string AssetTypeName { get; set; }
        public string AssetName { get; set; }
        public string AssetSubTypeName { get; set; }
        public string AssetAssignedType { get; set; }
        public string Code { get; set; }
        public int? CodeSerial { get; set; }
        public string BrandName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string PurchaseDateMsg { get { return PurchaseDate == null ? "" : PurchaseDate.Value.ToString("dd-MMM-yyyy"); } }
        public decimal? PurchaseValue { get; set; }
        public decimal? ValueAfterDeprication { get; set; }
        public int? CompanyID { get; set; }
        public int? DivisionID { get; set; }
        public decimal? DepriciationPercent { get; set; }
        public string DapricationDateFrom { get; set; }
        public string DapricationDateTo { get; set; }

        //Deprication
        public decimal Rate { get; set; }
        public decimal DepricationValue { get; set; }
        public int? FiscalYear { get; set; }

    }
}
