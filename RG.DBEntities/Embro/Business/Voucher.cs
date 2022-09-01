using RG.DBEntities.Embro.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Embro.Business
{
    public class Voucher
    {
        public Voucher()
        {
            Voucherdetail = new HashSet<Voucherdetail>();
            VoucherGeneralInfo = new HashSet<VoucherGeneralInfo>();
            //BankVoucherInfo = new HashSet<BankVoucherInfo>();
            //CbmRelateEcfRfpChqVoucher = new HashSet<CBM_Relate_ECF_RFP_CHQ_VOUCHER>();
            //CbmVoucherBillToBillPayment = new HashSet<cbm_VoucherBillToBillPayment>();
            //EsvagentInfo = new HashSet<ESVAgentInfo>();
            //ExportSalesVoucherInfo = new HashSet<ExportSalesVoucherInfo>();
            JournalVoucherInfo = new HashSet<JournalVoucherInfo>();
            //LCVoucherInfo = new HashSet<LCVoucherInfo>();
            //LocalSalesCustomerInfo = new HashSet<LocalSalesCustomerInfo>();
            //LocalSalesVoucherInfo = new HashSet<LocalSalesVoucherInfo>();
            PurchaseVoucherInfo = new HashSet<PurchaseVoucherInfo>();
        }

        public decimal ID { get; set; }
        public string VoucherNumber { get; set; }
        public int? VoucherType { get; set; }
        public DateTime? VDate { get; set; }
        public int CompanyId { get; set; }
        public int BusinessId { get; set; }
        public decimal? PreparedBy { get; set; }
        public decimal? CheckedBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? IndividualVoucherId { get; set; }
        public string VoucherDescription { get; set; }
        public decimal? AuthorizedBy { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public DateTime? PrepareDate { get; set; }
        public int? SystemVoucher { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiredBy { get; set; }
        public string EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? NoOfDays { get; set; }
        public string PaymentTerm { get; set; }
        public int SubVoucherType { get; set; }
        public DateTime RDate { get; set; }
        public int? StoreId { get; set; }
        public decimal? CRate { get; set; }
        public decimal? AmtInDoller { get; set; }

        public virtual ICollection<Voucherdetail> Voucherdetail { get; set; }
        public ICollection<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }
        //public virtual VoucherType_setup VoucherTypeNavigation { get; set; }
        //public virtual APM_Invoice_Detail APM_Invoice_Detail { get; set; }
        //public virtual ICollection<BankVoucherInfo> BankVoucherInfo { get; set; }
        //public virtual ICollection<CBM_Relate_ECF_RFP_CHQ_VOUCHER> CbmRelateEcfRfpChqVoucher { get; set; }
        //public virtual ICollection<cbm_VoucherBillToBillPayment> CbmVoucherBillToBillPayment { get; set; }
        //public virtual ICollection<ESVAgentInfo> EsvagentInfo { get; set; }
        //public virtual ICollection<ExportSalesVoucherInfo> ExportSalesVoucherInfo { get; set; }
        public virtual ICollection<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        //public virtual ICollection<LCVoucherInfo> LCVoucherInfo { get; set; }
        //public virtual ICollection<LocalSalesCustomerInfo> LocalSalesCustomerInfo { get; set; }
        //public virtual ICollection<LocalSalesVoucherInfo> LocalSalesVoucherInfo { get; set; }
        public virtual ICollection<PurchaseVoucherInfo> PurchaseVoucherInfo { get; set; }
    }
}
