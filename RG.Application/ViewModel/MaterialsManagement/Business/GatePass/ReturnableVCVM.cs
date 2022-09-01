using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class ReturnableVCVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Narrow Group")]
        public int? NarrowGroupType { get; set; }
        [Display(Name = "Identification")]
        public int? Identification { get; set; }
        [Display(Name = "Department")]
        [Required]
        public long? DepartmentID { get; set; }
        public string IdentificationName { get; set; }
        [Required]
        [Display(Name = "Vendor")]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        [Display(Name = "Contct Person")]
        public string VendorRepresentative { get; set; }
        [Display(Name = "Representative Contact No")]
        public string VendorRepresentativeContactNo { get; set; }
        [Display(Name = "Representative")]
        public string CompanyRepresentative { get; set; }
        [Display(Name = "Representative ID")]
        public string CompanyRepresentativeID { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }
        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Measurement Unit")]
        public string UnitOfMeasurementID { get; set; }

        [Display(Name = "Gross Weight")]
        [Required]
        public decimal GrossWeight { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Expected Return Date")]
        [Required]
        public string ReturnDate { get; set; }
        public bool? isSelfVehicle { get; set; }
        [Display(Name = "Category Name")]
        public int ReturnableItemCategoryID { get; set; }
        [Display(Name = "Requisition No")]
        public int RequisitionID { get; set; }
        public List<SelectListItem> RequisitionList { get; set; }
        public List<SelectListItem> ReturnableItemCategoryList { get; set; }
        public List<SelectListItem> NarrowGroupTypeList { get; set; }
        public List<SelectListItem> IdentificationList { get; set; }
        public List<SelectListItem> VendorList { get; set; }
        public List<SelectListItem> UnitOfMeasurementList { get; set; }
        public List<ReturnableItemVM> ReturnableItem { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
    }
    public class ReturnableItemVM
    {
        public long ID { get; set; }
        public int ReturnableItemCategoryID { get; set; }
        public string ReturnableItemCategory { get; set; }
        public int RequisitionID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal? GrossWeight { get; set; }
        public string ReturnDate { get; set; }
        public string Remarks { get; set; }
    }
}
