using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetIndexs
{
    public class AssetIndexVM
    {
        [Display(Name = "Asset")]
        public int? AssetID { get; set; }
        [Display(Name = "Building")]
        public int? BuildingID { get; set; }
        [Display(Name = "Floor")]
        public int? FloorID { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }

        [Display(Name = "Asset Type")]
        public int? AssetTypeName { get; set; }
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }
        [Display(Name = "Asset Sub Type")]
        public int? AssetSubTypeID { get; set; }
        [Display(Name = "Asset Assigned Type")]
        public int? AssetAssignedType { get; set; }
        public string Code { get; set; }
        public int? CodeSerial { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Value")]
        public decimal? PurchaseValue { get; set; }
        [Display(Name = "Value After Deprication")]
        public decimal? ValueAfterDeprication { get; set; }
        [Display(Name = "Company")]
        public int? CompanyID { get; set; }
        [Display(Name = "Division")]
        public int? DivisionID { get; set; }
        [Display(Name ="Fiscal Year")]
        public int? FiscalYear { get; set; }
        public int SearchingType { get; set; }

        //For DDL
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLEmployeeType { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLLBuildingFloor { get; set; }
        public List<SelectListItem> DDLDevision { get; set; }
        public List<SelectListItem> DDLAssetTypeName { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLAssetAssignedType { get; set; }
        public List<SelectListItem> DDLAssetSubTypeName { get; set; }
        public List<SelectListItem> DDLAssetName { get; set; }
        public List<SelectListItem> DDLSearchingType{ get; set; }
        public List<SelectListItem> DDLYear { get; set; }


    }
}
