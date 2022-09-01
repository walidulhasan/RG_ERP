using Microsoft.EntityFrameworkCore;
using RG.DBEntities.Embro.Business;
using RG.DBEntities.Embro.DBViews;
using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro
{
    public interface IEmbroDBContext
    {
        #region Business
        public  DbSet<APM_Invoice_Detail> APM_Invoice_Detail { get; set; }
        public DbSet<APM_Invoice_Main> APM_Invoice_Main { get; set; }
        public DbSet<APM_Invoice_Status> APM_Invoice_Status { get; set; }
        public DbSet<CBM_ChequeBook> CBM_ChequeBook { get; set; }
        public DbSet<APM_Payment_Modes> APM_Payment_Modes { get; set; }
        public DbSet<CostCenterLocation> CostCenterLocation { get; set; }
        public DbSet<CBM_Cheque> CBM_Cheque { get; set; }
        public DbSet<GeneralParameters> GeneralParameters { get; set; }
        public DbSet<LCS_Association_Main> LCS_Association_Main { get; set; }
        public DbSet<AdvancePayment> AdvancePayment { get; set; }
        public DbSet<BankVoucherInfo> BankVoucherInfo { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<CBM_Relate_ECF_RFP_CHQ_VOUCHER> CBM_Relate_ECF_RFP_CHQ_VOUCHER { get; set; }
        public DbSet<CBM_RFP> CBM_RFP { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayment { get; set; }
        public DbSet<CBM_RFP_Detail> CBM_RFP_Detail { get; set; }
        public DbSet<SupplierBankInfo> SupplierBankInfo { get; set; }
        public DbSet<tbl_CBM_AdvancePayment> tbl_CBM_AdvancePayment { get; set; }
        public DbSet<tbl_CBM_AdvancePayment_RFP_Relate> tbl_CBM_AdvancePayment_RFP_Relate { get; set; }
        public DbSet<CBM_BillToBillPayment> CBM_BillToBillPayment { get; set; }
        public DbSet<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        public DbSet<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }
        public DbSet<VoucherParameters> VoucherParameters { get; set; }
        public DbSet<PurchaseVoucherInfo> PurchaseVoucherInfo { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<Voucherdetail> Voucherdetail { get; set; }
        public DbSet<LeaseLoanPayment> LeaseLoanPayment { get; set; }
        public DbSet<LocalSalesCustomerInfo> LocalSalesCustomerInfo { get; set; }


        #endregion Business

        #region Setup
        //FiscalYearSetup
        public  DbSet<FiscalYearSetup> FiscalYearSetup { get; set; }
        public  DbSet<CBM_ChequeStatus> CBM_ChequeStatus { get; set; }
        public  DbSet<CBM_Currency> CBM_Currency { get; set; }
        public  DbSet<BankContactInfo> BankContactInfo { get; set; }
        public  DbSet<CBM_Employee> CBM_Employee { get; set; }
        public  DbSet<BasicCOA> BasicCOA { get; set; }
        public  DbSet<CBM_Instrument_Type> CBM_Instrument_Type { get; set; }
        public  DbSet<CBM_ACTYPE> CBM_ACTYPE { get; set; }
        public  DbSet<CBM_Parameters> CBM_Parameters { get; set; }
        public  DbSet<CBM_Bank> CBM_Bank { get; set; }
        public  DbSet<CBM_PrintedChequeStatus> CBM_PrintedChequeStatus { get; set; }
        public  DbSet<CBM_PrintedCheque> CBM_PrintedCheque { get; set; }
                
        public  DbSet<CBM_BankAccountSetup> CBM_BankAccountSetup { get; set; }
        public  DbSet<CBM_Branch> CBM_Branch { get; set; }
        public  DbSet<ChequeSignatoryMaster> ChequeSignatoryMaster { get; set; }
        public  DbSet<ClosingTypes> ClosingTypes { get; set; }
        public  DbSet<CustomerSetup> CustomerSetup { get; set; }
        public  DbSet<ERP_PaymentModes> ERP_PaymentModes { get; set; }
        public  DbSet<CustomerDetail> CustomerDetail { get; set; }
        public  DbSet<ERP_PaymentTerms> ERP_PaymentTerms { get; set; }
        public  DbSet<DepriciationMethod> DepriciationMethod { get; set; }
        public  DbSet<DepriciationPolicy> DepriciationPolicy { get; set; }
        public  DbSet<tbl_Currency_Setup> tbl_Currency_Setup { get; set; }
        public  DbSet<tbl_Currency_Detail> tbl_Currency_Detail { get; set; }
        public  DbSet<EntryTypeSetup> EntryTypeSetup { get; set; }
        public  DbSet<FSG_Setup_Master> FSG_Setup_Master { get; set; }
        public  DbSet<GeneralSetupDetail> GeneralSetupDetail { get; set; }
        public  DbSet<GeneralConfigurationSetup> GeneralConfigurationSetup { get; set; }
        public  DbSet<GeneralSetupMaster> GeneralSetupMaster { get; set; }
        public  DbSet<LetterType> LetterType { get; set; }
        public  DbSet<Levels> Levels { get; set; }
        public  DbSet<VoucherType_setup> VoucherType_setup { get; set; }
        public  DbSet<SupplierSetup> SupplierSetup { get; set; }
        public  DbSet<SupplierDetail> SupplierDetail { get; set; }
        public  DbSet<VoucherConfigurationSetup> VoucherConfigurationSetup { get; set; }
        public  DbSet<CompanyInfo> CompanyInfo { get; set; }
        public  DbSet<CBM_ECFDetail> CBM_ECF { get; set; }
        public  DbSet<CBM_ECFDetail> CBM_ECFDetail { get; set; }
        public  DbSet<CBM_LRP> CBM_LRP { get; set; }
        public  DbSet<CBM_LRP_Detail> CBM_LRP_Detail { get; set; }
        public  DbSet<ChequeSignatoryDetail> ChequeSignatoryDetail { get; set; }
        public  DbSet<FixedAsset> FixedAsset { get; set; }
        public  DbSet<COAGroup> COAGroup { get; set; }
        public  DbSet<COAGroupCategory> COAGroupCategorie { get; set; }
        public  DbSet<COAGroupIdentification> COAGroupIdentification { get; set; }
        public  DbSet<COAGroupIgnoredItem> COAGroupIgnoredItem { get; set; }
        public  DbSet<IncomeStatementGroupMap> IncomeStatementGroupMap { get; set; }
        public  DbSet<LoanType> LoanType { get; set; }
        public  DbSet<BalanceSheetGroupMap> BalanceSheetGroupMap { get; set; }

        //
        #endregion Setup
        #region View
        public  DbSet<vw_ItemAccounts_OfCompany> vw_ItemAccounts_OfCompany { get; set; }
        public  DbSet<vw_getItemAccounts_OfCompany> vw_getItemAccounts_OfCompany { get; set; }
        public  DbSet<Vw_BasicCOA> Vw_BasicCOA { get; set; }

        #endregion
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
