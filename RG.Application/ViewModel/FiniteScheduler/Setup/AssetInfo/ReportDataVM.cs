using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo
{
    public class ReportDataVM
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public int AssetSubTypeID { get; set; }
        public string AssetSubTypeName { get; set; }
        public int AssetAssignedType { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }

        public string Code { get; set; }
        public string BrandName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseDateMsg { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal? DepriciationPercent { get; set; }
        public decimal ValueAfterDeprication { get; set; }
        public decimal AccumulatedDeprication { get { return PurchaseValue - ValueAfterDeprication; } }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int FunctionalStatusID { get; set; }
        public string FunctionalStatus { get; set; }
        public decimal? Capacity { get; set; }
        public int? CapacityUnitID { get; set; }
        public string CapacityUnit { get; set; }
        public string ModelNo { get; set; }
        public string LCNo { get; set; }
        public int? BuildingID { get; set; }
        public int? FloorID { get; set; }
        public string Location { get; set; }
        public int DivisionID { get; set; }
        public string Division { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public string Remarks { get; set; }
        public List<DataAttributeVM> DataAttribute { get; set; }

    }
    
    public class DataAttributeVM {
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeShortName { get; set; }
        public int PrioritySerial { get; set; }
        public bool IsVisible { get; set; }
        public string AttributeValue { get; set; }
    }
}
