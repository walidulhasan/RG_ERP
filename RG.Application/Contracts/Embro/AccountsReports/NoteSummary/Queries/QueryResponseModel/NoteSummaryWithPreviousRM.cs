using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Embro.AccountsReports.NoteSummary.Queries.QueryResponseModel
{
    public class NoteSummaryWithPreviousRM
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public decimal? GroupCategoryID { get; set; }
        public decimal OBDebit { get; set; }
        public decimal OBCredit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal CumulativeBalance { get; set; }
        public decimal OldOBDebit { get; set; }
        public decimal OldOBCredit { get; set; }
        public decimal OldDebit { get; set; }
        public decimal OldCredit { get; set; }
        public decimal OldCurrentBalance { get; set; }
        public decimal OldCumulativeBalance { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string PrevDateFrom { get; set; }
        public string PrevDateTo { get; set; }

        public int HeaderID { get; set; }
        public string HeaderName { get; set; }
        public int SubHeaderID { get; set; }
        public string SubHeader { get; set; }
        public int SubHeaderSerial { get; set; }
        public int RowSerial { get; set; }
        public string Particulars { get; set; }

        public int? ParticularSerial { get; set; }
        public string MathActions { get; set; }
        public decimal? CalculationPercent { get; set; }
        public string UniqueCalculationCode { get; set; }
        //public string GroupCategoryName { get; set; }
        //public int? GroupID { get; set; }
        //public string GroupName { get; set; }
        //public string Particulars { get; set; }
        //public int SummaryGroupSerial { get; set; }
        //public string MathActionType { get; set; }
        //public int? FromGroupSerial { get; set; }
        //public int? ToGroupSerial { get; set; }
        //public decimal? CalculationPercent { get; set; }
        //public int? GroupSerial { get; set; }
        //public string GroupCode { get; set; }
        //public decimal? CID { get; set; }
        //public string Category { get; set; }
        //public string CategoryAccountCode { get; set; }
        //public decimal? SCID { get; set; }
        //public string SubCateogory { get; set; }
        //public string SubCateogoryAccountCode { get; set; }
        //public int? ValueCondition { get; set; }
        //public int? HeaderCOAGroupID { get; set; }
        //public string HeaderCOAGroup { get; set; }

    }

    public class NoteSummeryGroupData
    {
        public int RowSerial { get; set; }
        public decimal GroupCurrentYeraAmount { get; set; }
        public decimal GroupPreviousYearAmount { get; set; }
    }
}
