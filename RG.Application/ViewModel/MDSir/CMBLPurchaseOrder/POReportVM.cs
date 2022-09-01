using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.ViewModel.MDSir.CMBLPurchaseOrder
{
    public class POReportVM
    {
        public long POID { get; set; }
        public string PODate { get; set; }
        public long PONO { get; set; }
        public string POStatus { get; set; }
        public string DeliveryLocation { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int? AdvancePercentage { get; set; }
        public string LCNo { get; set; }
        public string UserName { get; set; }

        public decimal PoAmount { get; set; }
        public int SupplierId { get; set; }
        public int CompanyID { get; set; }


        public POSupplierInfoVM POSupplierInfo { get; set; }
        public POCompanyInfoVM POCompanyInfo { get; set; }
        public List<PORequisitionVM> PORequisition { get; set; }
        public List<POItemVM> POItem { get; set; }
        public List<POQuotationFile> POQuotationFile { get; set; }
    }
    public class POSupplierInfoVM
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNo { get; set; }
        public string SupplierMobileNo { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
    }
    public class POCompanyInfoVM
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string FactoryAddress { get; set; }
    }
    public class PORequisitionVM
    {
        public long IRID { get; set; }
        public long RequisitionNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string RequisitionDateST { get { return RequisitionDate.ToString("dd-MMM-yyyy"); } }
        public string RequisitionComments { get; set; }
        public string Buyer { get; set; }
        public string OrderNo { get; set; }
        public string UserName { get; set; }


    }
    public class POItemVM
    {
        public string Unit { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public long RequisitionNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateST { get { return DeliveryDate.ToString("dd-MMM-yyyy"); } }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public decimal AmountTotal { get { return Rate * Quantity; } }
        public string UserName { get; set; }
        public long POID { get; set; }

    }

    public class POQuotationFile
    {
        public long POAttachmentID { get; set; }
        public long POID { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadDateST { get; set; }
        public int FileSerial { get; set; }
        public string Comments { get; set; }
        public string FileName { get; set; }
        public string FileUri { get; set; }
    }

}
