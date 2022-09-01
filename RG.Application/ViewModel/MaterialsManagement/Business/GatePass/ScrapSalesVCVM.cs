using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class ScrapSalesVCVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Customer")]
        public long CustomerID { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        [Display(Name = "Persons Name")]
        public string PersonsName { get; set; }
        [Display(Name = "Lab Sample No")]
        public string LabSampleNo { get; set; }
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Measurement Unit")]
        public string UnitOfMeasurementID { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        [Display(Name = "First Weight")]
        public decimal FirstWeight { get; set; }
        [Display(Name = "Second Weight")]
        public decimal SecondWeight { get; set; }
        public decimal? Rate { get; set; }
        public double Quantity { get; set; }
        public string VehicleDriverMobileNo { get; set; }
        public bool IsSelfVehicle { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> UnitOfMeasurementList { get; set; }
        public List<ScrapSalesItemVM> ScrapSalesItem { get; set; }
    }
    public class ScrapSalesItemVM
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double? Rate { get; set; }
        public string Remarks { get; set; }
    }
}
