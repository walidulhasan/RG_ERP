using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.GeneralLedgers.Queries.QueryResponseModel
{
    public class GeneralLedgerDetailReportRM
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Companyname { get; set; }
        public string Address { get; set; }
        public string CostCenterName { get; set; }
        public string LEVEL_1 { get; set; }
        public string LEVEL_2 { get; set; }
        public string LEVEL_3 { get; set; }
        public string LEVEL_4 { get; set; }
        public string LEVEL_5 { get; set; }
        public string LEVEL_6 { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public decimal? VOUCHERID { get; set; }
        public string InvoiceNumner { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime? VDate { get; set; }
        public string VoucherDescription { get; set; }
        public DateTime? RDate { get; set; }
        public int? VoucherType { get; set; }
        public int? ACCOUNTID { get; set; }
        public decimal? DR_AMOUNT { get; set; }
        public decimal? CR_AMOUNT { get; set; }
        public string RefNo { get; set; }
        public string Comments { get; set; }
        public string Location { get; set; }
        public string CostCenter { get; set; }
        public string Activity { get; set; }
        public string Initials { get; set; }

    }
}
