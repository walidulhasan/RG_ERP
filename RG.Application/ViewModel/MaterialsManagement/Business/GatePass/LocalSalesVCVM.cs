using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class LocalSalesVCVM
    {
        public LocalSalesVCVM()
        {
            LocalSalesItems = new List<LocalSalesItemVM>();
        }
        public long GatePassID { get; set; }
        [Display(Name = "Department")]
        public long DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        [Display(Name = "Customer")]
        public long CustomerID { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }
        [Display(Name = "Process Name")]
        public int Process { get; set; }

        public int OrderID { get; set; }
        [Display(Name = "Issuance No")]
        public long IssuanceNo { get; set; }
        [Display(Name = "Issuance Detail")]
        public long IssuanceDetailID { get; set; }
        [Display(Name = "Work Order No")]
        public string WorkOrderNo { get; set; }
        public long PaymentMode { get; set; }
        [Display(Name = "Payment Mode")]
        public string PMDescription { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Process Code")]
        public string ProcessCode { get; set; }
        [Display(Name = "Finish Code")]
        public string FinishCode { get; set; }
        [Display(Name = "Measurement Unit")]
        public string UnitOfMeasurementID { get; set; }
        [Display(Name = "Quantity")]
        public decimal Quantity { get; set; }
        [Display(Name = "Gross Weight")]
        public decimal GrossWeight { get; set; }
        [Display(Name = "Net Weight")]
        public decimal NetWeight { get; set; }
        [Display(Name = "Total Roll")]
        public string Roll { get; set; }
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }
        [Display(Name = "Finished Width")]
        public decimal FinishedWidth { get; set; }
        [Display(Name = "Greige Width")]
        public decimal GreigeWidth { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Customer Challan No")]
        public string ReceivedChallanNo { get; set; }
        public bool? isSelfVehicle { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<SelectListItem> ProcessList { get; set; }
        public List<SelectListItem> IssuanceList { get; set; }
        public List<SelectListItem> UnitOfMeasurementList { get; set; }
        public List<SelectListItem> IssuanceDetailList { get; set; }
        public List<SelectListItem> WorkOrderNoList { get; set; }
        public List<LocalSalesItemVM> LocalSalesItems { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> DDLPaymentMode { get; set; }
        
    }

    public class LocalSalesItemVM
    {
        public long ID { get; set; }
        public long? IssuanceMasterID { get; set; }
        public long? IssuanceDetailID { get; set; }
        public int? ProcessId { get; set; }
        public int? OrderID { get; set; }
        public string OrderName { get; set; }
        public int? PaymentMode { get; set; }
        public string PMDescription { get; set; }
        public string ProcessName { get; set; }
        public string WorkOrderNo { get; set; }
        public string ItemDetail { get; set; }
        public string ProcessCode { get; set; }
        public string FinishCode { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal? Rate { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? GrossWeight { get; set; }
        public string RollCount { get; set; }
        public string Remarks { get; set; }
        public string RefNo { get; set; }
        public decimal? GreigeWidth { get; set; }
        public decimal? FinishedWidth { get; set; }

    }
}
