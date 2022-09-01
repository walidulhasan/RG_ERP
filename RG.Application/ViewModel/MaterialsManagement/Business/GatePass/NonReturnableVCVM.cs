using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class NonReturnableVCVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        [Display(Name = "Issued To")]
        public long? CustomerID { get; set; }
        [Display(Name = "Issued To")]
        public string IssuedTo { get; set; }
        public string Purpose { get; set; }
        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Measurement Unit")]
        public string UnitOfMeasurementID { get; set; }
        [Display(Name = "Gross Weight")]
        public decimal GrossWeight { get; set; }
        public double Quantity { get; set; }
        public string Remarks { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> UnitOfMeasurementList { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<NonReturnableItemVM> NonReturnableItems { get; set; }
    }
    public class NonReturnableItemVM
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double GrossWeight { get; set; }
        public string Remarks { get; set; }
        public long NonReturnableGatePassID { get; set; }
    }
}
