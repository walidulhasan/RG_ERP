using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class SampleGmtsVCVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Customer Type")]
        public int? CustomerTypeID { get; set; }

        [Display(Name = "Customer")]
        public int? CustomerID { get; set; }
        [Display(Name = "Customer")]
        public string CustomerName { get; set; }
        [Display(Name = "Sample Type")]
        public int SampleTypeID { get; set; }
        [Display(Name = "Sample Process")]
        public int SampleProcessTypeID { get; set; }

        [Display(Name = "Order No")]
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }

        [Display(Name = "Development No")]
        public string ReferenceNo { get; set; }

        [Display(Name = "Carrier")]
        public string CarrierName { get; set; }

        [Display(Name = "Description")]
        public string SampleDescription { get; set; }

        [Display(Name = "Lab Sample No")]
        public string LabSampleNo { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Measurement Unit")]
        public string UnitOfMeasurementID { get; set; }

        [Display(Name = "First Weight")]
        public decimal FirstWeight { get; set; }
        [Display(Name = "Second Weight")]
        public decimal SecondWeight { get; set; }
        public double Quantity { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public List<SelectListItem> UnitOfMeasurementList { get; set; }

        public List<SelectListItem> DDLCustomerType { get; set; }
        public List<SelectListItem> DDLCustomer { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLSampleType { get; set; }
        public List<DropDownItem> DDLSampleTypeProcess { get; set; }
        public List<SelectListItem> DDLDepartment { get; set; }
        public List<SampleItemVM> SampleItems { get; set; }

    }
    public class SampleItemVM
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public double Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string Remarks { get; set; }


    }
}
