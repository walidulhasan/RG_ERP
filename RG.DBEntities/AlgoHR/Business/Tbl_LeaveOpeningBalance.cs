namespace RG.DBEntities.AlgoHR.Business
{
    public class Tbl_LeaveOpeningBalance
    {
        public int ID { get; set; }
        public string EmpCD { get; set; }
        public int Year { get; set; }
        public int LeaveID { get; set; }
        public int OpeningBalance { get; set; }
    }
}
