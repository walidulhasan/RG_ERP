namespace RG.DBEntities.AlgoHR.Setup
{
    public class CompanyKPIParticulars : DefaultTableProperties
    {
        public int ID { get; set; }
        public int Serial { get; set; }
        public string ParticularHead { get; set; }
        public string Particulars { get; set; }
        public int DecimalUpTo { get; set; }
        public bool AutoCalculation { get; set; }
    }
}
