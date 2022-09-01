using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RG.Application.ViewModel.MaterialsManagement.Business.GatePass
{
    public class GatePassChallanMasterVM
    {
        public GatePassChallanMasterVM()
        {
            GatePassChallanDetails = new List<GatePassChallanDetailsVM>();
        }
        /// <summary>
        /// ReportType   1=>Gate Pass;  2=>Challan;
        /// </summary>
        public int ReportType { get; set; } = 1;
        public long GatePassID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Serial { get; set; }
        public string DateTimeStamp { get; set; }
        public string VehicleNo { get; set; }
        public byte CategoryID { get; set; }
        public string IssuedTo { get; set; }
        public string IssuedBy { get; set; }
        public bool IsApproved { get; set; }
        public long? PreparedBy { get; set; }
        public string PreparedByUser { get; set; }
        public long? ApprovedBy { get; set; }
        public string ApprovedUser { get; set; }
        public bool? IsApprovedByAccounts { get; set; }
        public long? AccountsApprovedBy { get; set; }
        public string AccountsApprovedUser { get; set; }
        public string Purpose { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string VehicleRef { get; set; }
        //  public string ShippingLine { get; set; }
        // public string Container { get; set; }
        public string VendorSupplier { get; set; }
        public string RepresentativeContact { get; set; }
        public string Representative { get; set; }
        public string Description { get; set; }
        public string DriverName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }
        public string MobileNo { get; set; }
        public string TransportServiceName { get; set; }
        public string CategoryName { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool? isMarkedOut { get; set; }
        public string OrderReferenceNo { get; set; }
        public string CarrierName { get; set; }
        public string WeightSlipNo { get; set; }
        public string Remarks { get; set; }
        public string PaymentModeName { get; set; }
        public int PaymentMode { get; set; }
        public string CustomerChallanNo { get; set; }
        public string CustomerAddress { get; set; }
        public List<SelectListItem> PaymentTypeList { get; set; }
        public List<GatePassChallanDetailsVM> GatePassChallanDetails { get; set; }
    }
}
