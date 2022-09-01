namespace RG.DBEntities.AlgoHR.Business
{
    public class DivisionSalaryCost
    {
        public int SalaryCostID { get; set; }
        public int SalaryAnalysisDivisionID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Department { get; set; }
        public int Manpower { get; set; }
        public decimal Salary { get; set; }
        public decimal Overtime { get; set; }
        public decimal Allowance { get; set; }
        public decimal? ExtraOvertime { get; set; }
    }
}
