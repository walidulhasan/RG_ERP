using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfoIndexs
{
    public class AssetInfoIndexVM
    {
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public string Code { get; set; }
        [Display(Name ="Asset Type")]
        public int AssetTypeID { get; set; }
        public string TypeName { get; set; }
        [Display(Name ="Asset Sub Type")]
        public int AssetSubTypeID { get; set; }
        public string SubTypeName { get; set; }
        public int CodeSerial { get; set; }
        public string BrandName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public bool IsFreeAsset { get; set; }
        public string EmployeeCode { get; set; }
        [Display(Name = "Name")]
        public string EmployeeName { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        [Display(Name = "Division")]
        public string DivisionName { get; set; }
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }
        [Display(Name = "Section")]
        public string SectionName { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Appointment Date")]
        public string AppointmentDate { get; set; }
        public bool CanApplyForOthers { get; set; }
        public virtual List<SelectListItem> DDLAssetTypeName { get; set; }
        public virtual List<SelectListItem> DDLAssetSubType { get; set; }
        public virtual List<SelectListItem> DDLEmployee { get; set; }

        //AssetLoaction
        public int AssetLoactionID { get; set; }
        [Display(Name = "Building")]
        public int BuildingID { get; set; }
        [Display(Name = "Floor")]
        public int FloorID { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeCode2 { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Company")]
        public int LoaCompanyID { get; set; }
        [Display(Name = "Division")]
        public int OfficeDivisionID { get; set; }
        public bool IsReturned { get; set; }
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLLBuildingFloor { get; set; }
        public List<SelectListItem> DDLEmployeeType { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLAssetAssignedType { get; set; }
        public List<SelectListItem> DDLAssetTypeName2 { get; set; }
        public List<SelectListItem> DDLDevision { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }

        //AssetDep
        public double Rate { get; set; }
    }
}
