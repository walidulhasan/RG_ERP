using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ChainSubContractorRates
    {
        public int Id { get; set; }
        public int SubContractorId { get; set; }
        public int StyleId { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string LeadTime { get; set; }
        public byte GarmentId { get; set; }
    }
}
