using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.AssetIndexs.Queries.RequestResponseModel
{
    public class GetAllAssetAndRelationalInfoQM
    {
        public int AssetID { get; set; }
        public int BuildingID { get; set; }
        public int FloorID { get; set; }
        public int DepartmentID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int AssetTypeName { get; set; }
        public string AssetName { get; set; }
        public int AssetSubTypeID { get; set; }
        public int AssetAssignedType { get; set; }
        public string Code { get; set; }
        public int CodeSerial { get; set; }
        public string BrandName { get; set; }
        //public DateTime? PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal ValueAfterDeprication { get; set; }
        public int CompanyID { get; set; }
        public int DivisionID { get; set; }
    }
}
