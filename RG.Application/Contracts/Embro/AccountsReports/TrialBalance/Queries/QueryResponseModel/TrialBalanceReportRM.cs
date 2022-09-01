namespace RG.Application.Contracts.Embro.AccountsReports.TrialBalance.Queries.QueryResponseModel
{
    public class TrialBalanceReportRM
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int SelectLevel { get; set; }
        public decimal CID { get; set; }
        public string Category { get; set; }
        public string CategoryAccountCode { get; set; }
        public decimal SCID { get; set; }
        public string SubCateogory { get; set; }
        public string SubCateogoryAccountCode { get; set; }
        public decimal BGID { get; set; }
        public string BroadGroup { get; set; }
        public string BroadGroupAccountCode { get; set; }
        public decimal NGID { get; set; }
        public string NarrowGroup { get; set; }
        public string NarrowGroupAccountCode { get; set; }
        public decimal IdentID { get; set; }
        public string IDENTIFICATION { get; set; }
        public string IDENTIFICATIONAccountCode { get; set; }
        public string ITEM { get; set; }
        public string ITEMAccountCode { get; set; }
        public long TopID { get; set; }
        public decimal OBDebit { get; set; }
        public decimal OBCredit { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal BalanceDebit { get; set; }
        public decimal BalanceCredit { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}
