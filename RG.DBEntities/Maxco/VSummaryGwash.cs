using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class VSummaryGwash
    {
        public int Id { get; set; }
        public long GwchainId { get; set; }
        public long StyleId { get; set; }
        public double FinalSmv { get; set; }
        public double Smv { get; set; }
        public double? ManualSmv { get; set; }
        public int? GarmentAssortment { get; set; }
    }
}
