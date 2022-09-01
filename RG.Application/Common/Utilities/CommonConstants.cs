using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Common.Utilities
{

    public static class PageInfo
    {
        public static string PageTitle = "PageTitle";
        public static string PageHeader = "PageHeader";
        public static string PageLink1 = "PageLink1";
        public static string PageLink2 = "PageLink2";
        public static string PageAdditionalInfo = "PageAdditionalInfo";
        public static string btnText1 = "btnText1";
        public static string btnText2 = "btnText2";
        public static string btnClass1 = "btnClass1";
        public static string btnClass2 = "btnClass2";
        public static string PageHeaderFaIcon = "PageHeaderFaIcon";
    }
    public class ApprovalModules
    {
        public const string MachineMaintenance = "Machine Maintenance";
        public const string LeaveApplication = "Leave Application";
        public const string OutsideOfficeWork = "Outside Office Work";
        public const string HRTraining = "HR Training";
    }
    public static class IC_DocumentCategoriesCC
    {
        public static string SampleGmts = "Sample Gmts";
        public static string LocalSales = "Local Sales";
        public static string NonReturnable = "Non-Returnable";
        public static string Returnable = "Returnable";
        public static string ExportSales = "Export Sales";
        public static string ScrapSales = "Scrap Sales";
    }
    public static class IC_DocumentCategoriesIDCC
    {
        public static int SampleGmts = 1;
        public static int LocalSales = 2;
        public static int NonReturnable = 3;
        public static int Returnable = 4;
        public static int ExportSales = 5;
        public static int ScrapSales = 6;
    }
    public static class UserClaimsCC
    {
        public static string GatePassInitialApproval = "GatePassInitialApproval";
        public static string GatePassAccountsCashApproval = "GatePassAccountsCashApproval";
        public static string GatePassAccountsChequeApproval = "GatePassAccountsChequeApproval";
        public static string GatePassAccountsLCApproval = "GatePassAccountsLCApproval";
        public static string GatePassReturnableReceive = "GatePassReturnableReceive";
        public static string GatePassMarkedOut = "GatePassMarkedOut";
        public static string GatePassReject = "GatePassReject";
        public static string LeaveSpecialApprove = "LeaveSpecialApprove";
        public static string LeaveSpecialCancel = "LeaveSpecialCancel";
        public static string LeaveSpecialEntry = "LeaveSpecialEntry";
        public static string PermissionCreateTrainingEvent = "PermissionCreateTrainingEvent";
        public static string LeaveAdjustmentPower = "LeaveAdjustmentPower";

    }
    /// <summary>
    /// FROM Embro.dbo.ERP_PaymentModes table
    /// </summary>
    public static class PaymentModes
    {
        public static int PaymentModeCash = 2;
        //public static int PaymentTypeCheque = 2;
        public static int PaymentModeLC = 4;
        
    }
    public static class FileUploadLocation
    {
        public static string LeaveAttachments = "ApplicationFiles\\LeaveAttachments";
        public static string TrainingDocuments = "ApplicationFiles\\TrainingDocuments";
        //public static string NomineeImage = "ApplicationFile\\Nominee\\NomineeImage";
        //public static string LoanDocument = "ApplicationFile\\LoanDocument";
        //public static string CompanyLogo = "ApplicationFile\\CompanyLogo\\LogoImage";
    }

}
