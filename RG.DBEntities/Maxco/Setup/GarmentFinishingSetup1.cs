using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class GarmentFinishingSetup1
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int GarmentFinishingId { get; set; }
        public double LeadTime { get; set; }
        public double? OperationRate { get; set; }
        public bool? IsOutSource { get; set; }
        public string OutSourceDetail { get; set; }
        public short GroupNo { get; set; }
        public int NoOfPersons { get; set; }
        public bool IsFinishing { get; set; }
    }
}
