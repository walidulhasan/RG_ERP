namespace RG.DBEntities.Embro.Setup
{
    public class BalanceSheetGroupMap
    {
        public int ID { get; set; }
        public int HeaderID { get; set; }
        public string HeaderName { get; set; }
        public int SubHeaderID { get; set; }
        public string SubHeader { get; set; }
        public int SubHeaderSerial { get; set; }
        public int RowSerial { get; set; }
        public string UniqueCalculationCode { get; set; }
        public string Particulars { get; set; }
        public int? ParticularSerial { get; set; }
        public int? COAGroupID { get; set; }
        public int? GroupCategoryID { get; set; }
        public string MathActions { get; set; }
        public decimal? CalculationPercent { get; set; }
        public int? ValueType { get; set; }
    }
}
