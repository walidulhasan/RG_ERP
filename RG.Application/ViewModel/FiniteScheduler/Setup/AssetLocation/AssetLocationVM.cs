using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RG.Application.ViewModel.FiniteScheduler.Setup.AssetLocation
{
    public class AssetLocationVM
    {
        public int ID { get; set; }
        [Display(Name ="Asset")]
        public int AssetID { get; set; }
        [Display(Name = "Building")]
        public int BuildingID { get; set; }
        [Display(Name = "Floor")]
        public int FloorID { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        [Display(Name = "Employee")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }
        public bool IsReturned { get; set; }
        public List<SelectListItem> DDLBuilding { get; set; }
        public List<SelectListItem> DDLLBuildingFloor { get; set; }
        public List<SelectListItem> DDLEmployeeType { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
    }
}
