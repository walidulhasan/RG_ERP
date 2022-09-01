using System;

namespace RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel
{
    public class WeeklyExportDetailsReportRM
    {
        public string Companyname { get; set; }
        public string CompanyShortName { get; set; }
        public decimal CompanyID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public string EXPOrderNo { get; set; }
        public string Department { get; set; }
        public int EPIM_ID { get; set; }
        public string EPIM_SHIPEDTO { get; set; }
        public string EPIM_INVOICENO { get; set; }
        public int NoOfCartons { get; set; }
        public int TotalGarments { get; set; }
        public string EPIM_INVOICEUNIT { get; set; }
        public decimal EPIM_AVG_PRICE { get; set; }
        public long EPIM_Quantity { get; set; }
        public decimal EPIM_AMOUNT { get; set; }
        public DateTime? EPIM_Stuffing_Report_Date { get; set; }
        public string EPIM_Stuffing_Report_DateMsg { get { return EPIM_Stuffing_Report_Date == null ? "" : EPIM_Stuffing_Report_Date.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? EPIM_Onboard_Date { get; set; }
        public string EPIM_Onboard_DateMsg { get { return EPIM_Onboard_Date == null ? "" : EPIM_Onboard_Date.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? EPIM_Payment_Sub_Portal { get; set; }
        public string EPIM_Payment_Sub_PortalMsg { get { return EPIM_Payment_Sub_Portal == null ? "" : EPIM_Payment_Sub_Portal.Value.ToString("dd-MMM-yyyy"); } }
        public DateTime? EPIM_EXFACTORYDATE { get; set; }
        public string EPIM_EXFACTORYDATEMsg { get { return EPIM_EXFACTORYDATE == null ? "" : EPIM_EXFACTORYDATE.Value.ToString("dd-MMM-yyyy"); } }
        public int WeekNo { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
        public DateTime? PaymentReceivingDate { get; set; }
        public string GBCNonGBC { get; set; }
        public decimal NegotiateAmt { get; set; }
        public decimal ReceivedAmt { get; set; }
        public decimal OutstandingAmt { get; set; }
        public DateTime? EFVDate { get; set; }
        public DateTime? ERVDate { get; set; }
        public int ExceedDays { get; set; }
        public string EFVDateMsg { get { return EFVDate == null ? "" : EFVDate.Value.ToString("dd-MMM-yyyy"); } }
        public string ERVDateMsg { get { return ERVDate == null ? "" : ERVDate.Value.ToString("dd-MMM-yyyy"); } }
        public string ExpectedPaymentDateMsg { get { return ExpectedPaymentDate == null ? "" : ExpectedPaymentDate.Value.ToString("dd-MMM-yyyy"); } }
        public string PaymentReceivingDateMsg { get { return PaymentReceivingDate == null ? "" : PaymentReceivingDate.Value.ToString("dd-MMM-yyyy"); } }
    }
}
