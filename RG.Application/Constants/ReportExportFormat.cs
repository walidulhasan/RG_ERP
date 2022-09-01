using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Constants
{
    public static class ReportExportFormat
    {
        public static string PdfFormat = "PDF";
        public static string ExcelFormat = "EXCEL";
    }

    public static class EntrySource
    {
        /// <summary>
        /// Server Name 190, New Application 
        /// </summary>
        public static string Name190 = "APP-190";
    }
    public static class ReportFolder
    {
        public static string FiniteSchedulerFolder { get; private set; } = "FiniteScheduler_Report";
        public static string MaterialsManagementFolder { get; private set; } = "MaterialsManagement_Report";
        public static string AlgoHRFolder { get; private set; } = "AlgoHR_Report";
        public static string EmbroFolder { get; private set; } = "Embro_Report";
        public static string EMSFolder { get; private set; } = "EMS_Report";
    }

    public static class Constants_EmailReport
    {
        public static string ExcessDyeingPrintingWastage = "Excess Dyeing Printing Wastage";
        public static string DailyKnittingProductionReport = "Daily Knitting Production Report";
        public static string KnittingProductionDefectNotification = "Knitting Production Defect(s) Notification";
        public static string OverdueHnMInvoicesNotification = "Overdue HnM Invoices Notification";
        public static string SubContractReturnableGatepass = "Sub-Contract Returnable Gatepass";
        public static string RBLDelayedVoucherPostingERPFinancials = "RBL Delayed Voucher Posting in ERP Financials";
        public static string CBLDelayedVoucherPostingERPFinancials = "CBL Delayed Voucher Posting in ERP Financials";
        public static string CBLPendingDyeingLot = "CBL Pending Dyeing Lot";
        public static string RBLPendingDyeingLot = "RBL Pending Dyeing Lot";
        public static string UnsatisfiedReturnableGoods = "Unsatisfied Returnable Goods";
        public static string DailyYarnTransaction = "Daily Yarn Transaction";
        public static string BTBCashLCOverdueMaturityNotification = "BTB Cash LC Overdue Maturity Notification";
        public static string FDBPFDBC_EntryNotification = "FDBP/FDBC Entry Notification ";
        public static string DailyKnittingShiftAndMachineWiseKnittingDefects = "IE Report-2, Daily Knitting Shift & Machine Wise Knitting Defect(s)";
        public static string DailyKnittingShiftAndMachineWiseOverallPerformance = "IE Report-1, Daily Knitting Shift & Machine Wise overall Performance";
        public static string TopCuttingDefectsNotification = "Top Cutting Defects Notification";
        public static string LateDeliveryReportAccessoriesHnm = "Late Delivery Report Accessories, HnM";
        public static string LateDeliveryReportAccessoriesResOfBuyer = "Late Delivery Report Accessories, Rest Of Buyer(s)";
        public static string LateDeliveryReportConsumablesCBL = "Late Delivery Report Consumables, CBL";
        public static string LateDeliveryReportConsumablesRBL = "Late Delivery Report Consumables, RBL";
    }
}
