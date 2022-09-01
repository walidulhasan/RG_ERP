using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetInfo
{
    public class AssetInfoVM
    {
        public AssetInfoVM()
        {
            AssetWiseAttributeValues = new List<AssetWiseAttributeValuesVM>();
        }
        public int AssetID { get; set; }
        [Display(Name = "Asset Type")]
        public int AssetTypeName { get; set; }
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }
        [Display(Name = "Asset Sub Type")]
        public int AssetSubTypeID { get; set; }
        [Display(Name = "Asset Assigned Type")]
        public int AssetAssignedType { get; set; }
        public string Code { get; set; }
        public int CodeSerial { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Purchase Date")]
        public DateTime? PurchaseDate { get; set; }
        public string PurchaseDateMsg { get { return PurchaseDate == null ? DateTime.Now.ToString("dd-MMM-yyyy") : PurchaseDate.Value.ToString("dd-MMM-yyyy"); } }

        [Display(Name = "Purchase Value")]
        public decimal PurchaseValue { get; set; }
        [Display(Name = "Value After Deprication")]
        public decimal ValueAfterDeprication { get; set; }
        [Display(Name = "Company")]
        public int CompanyID { get; set; }
        public bool IsReturnable { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        public List<SelectListItem> DDLLocationCompany { get; set; }

        //AssetLoaction
        public int ID { get; set; }
        [Display(Name = "Building")]
        public int? BuildingID { get; set; }
        [Display(Name = "Floor")]
        public int? FloorID { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Company")]
        public int? LoaCompanyID { get; set; }
        [Display(Name = "Division")]
        public int? OfficeDivisionID { get; set; }
        public bool IsReturned { get; set; }
        [Display(Name = "Functional Status")]
        public int FunctionalStatusID { get; set; }
        [Display(Name = "Capacity")]
        public decimal? Capacity { get; set; }
        [Display(Name = "Capacity Unit")]
        public int? CapacityUnitID { get; set; }
        [Display(Name = "Model No")]
        public string ModelNo { get; set; }
        [Display(Name = "LC No")]
        public string LCNo { get; set; }

        public List<SelectListItem> DDLFunctionalStatus { get; set; }
        public List<SelectListItem> DDLCapacityUnit { get; set; }

        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLLBuildingFloor { get; set; }
        public List<SelectListItem> DDLEmployeeType { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SelectListItem> DDLAssetAssignedType { get; set; }
        public List<SelectListItem> DDLAssetTypeName { get; set; }
        public List<SelectListItem> DDLDevision { get; set; }
        public List<SelectListItem> DDLAssetSubTypeID { get; set; }

        //Asset Depriciation History
        [Display(Name = "Date From")]
        public string DapricationDateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DapricationDateTo { get; set; }
        [Display(Name = "Depriciation Percent")]
        public decimal DepriciationPercent { get; set; }
        public List<AssetWiseAttributeValuesVM> AssetWiseAttributeValues { get; set; }

    }
    public class AssetInfoVMValidator : AbstractValidator<AssetInfoVM>
    {
        public AssetInfoVMValidator()
        {
            RuleFor(b => b.AssetAssignedType).NotNull().WithMessage("Asset Assigned Type  is required.");
            RuleFor(b => b.AssetTypeName).NotNull().WithMessage("Asset Type is required.");
            RuleFor(b => b.AssetSubTypeID).NotNull().WithMessage("Asset Sub Type is required.");
            RuleFor(b => b.AssetName).NotNull().WithMessage("Asset Name  is required.");
            //RuleFor(b => b.Code).NotNull().WithMessage("Code  is required and can't be Duplicate.");
            RuleFor(b => b.PurchaseDate).NotNull().WithMessage("Purchase Date is required.");
            RuleFor(b => b.PurchaseValue).NotNull().WithMessage("Purchase Value is required.");
            RuleFor(b => b.CompanyID).NotNull().WithMessage("Company is required.");
            RuleFor(b => b.IsReturnable).NotNull().WithMessage("Returnable is required.");
            RuleFor(b => b.DapricationDateFrom).NotNull().WithMessage("Date From is required.");
            RuleFor(b => b.DepriciationPercent).NotNull().WithMessage("Percent is required And Will be (1 to 99).");


        }
    }
}
