namespace RG.DBEntities.AlgoHR.Business
{
    public class KPIParticularValues : DefaultTableProperties
    {
        public int ID { get; set; }
        public int ParticularID { get; set; }
        public int KPIMonth { get; set; }

        public int KPIYear { get; set; }
        public decimal? ParticularValue { get; set; }
        public bool IsCalculationParticular { get; set; }

    }
}
