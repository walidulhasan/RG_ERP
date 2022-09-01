using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class ExportSalesVCVM
    {
        public long GatePassID { get; set; }
        [Display(Name = "Issued To")]
        public string IssuedTo { get; set; }
        public string Purpose { get; set; }
        [Display(Name = "Vehicle No")]
        public string VehicleRef { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Unit Of Measurement")]
        public string UnitOfMeasurementID { get; set; }
        [Display(Name = "Department")]
        public long? DepartmentID { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Carton Quantity")]
        public int CartonQuantity { get; set; }
        [Display(Name = "PO No")]
        public string PONumber { get; set; }
        [Display(Name = "Invoice No")]
        public string InvoiceNumber { get; set; }
        [Display(Name = "Buyer Name")]
        public string BuyerName { get; set; }
        [Display(Name = "From E")]
        public string FromE { get; set; }
        public string Container { get; set; }
        [Display(Name = "Container Size")]
        public string ContainerSize { get; set; }
        public string Seal { get; set; }
        [Display(Name = "Shipping Line")]
        public string ShippingLine { get; set; }
        [Display(Name = "Clearing Agent")]
        public string ClearingAgent { get; set; }
        public string Remarks { get; set; }
        public string Description { get; set; }
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Display(Name = "Transport")]
        public string TransportServiceName { get; set; }
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [Display(Name = "Country")]
        public int? CountryID { get; set; }
        public List<SelectListItem> UnitOfMeasurementList { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<ExportSalesItemVM> ExportSalesItem { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }


        public string DataJson { get; set; }
    }
    public class ExportSalesItemVM
    {
        public long ID { get; set; }
        public string ItemName { get; set; }
        public int? UnitID { get; set; } = 0;
        public string UnitOfMeasurement { get; set; }
        public decimal? Quantity { get; set; } = 0;
        public long? CartonQuantity { get; set; } = 0;
        public int? BuyerID { get; set; } = 0;
        public string BuyerName { get; set; }
        public int? OrderID { get; set; } = 0;
        public string OrderNo { get; set; }
        public string PONumber { get; set; }
        public int? CountryID { get; set; } = 0;
        public string CountryName { get; set; }
        public string InvoiceNumber { get; set; }
        public string FromE { get; set; }
        public string Container { get; set; }
        public string ContainerSize { get; set; }
        public string Seal { get; set; }
        public string ShippingLine { get; set; }
        public string ClearingAgent { get; set; }
        public string Remarks { get; set; }
    }
}
