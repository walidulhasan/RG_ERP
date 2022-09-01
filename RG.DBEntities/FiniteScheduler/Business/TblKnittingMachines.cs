using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingMachines
    {
        public int MachineNo { get; set; }
        public int? Dia { get; set; }
        public string Brand { get; set; }
        public long? CompanyId { get; set; }
        public short? Floor { get; set; }
        public int? Guage { get; set; }
        public string Slength { get; set; }
        public int? Feeder { get; set; }
        public int? Rpm { get; set; }
        public int? Ycount { get; set; }
        public int? YType { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
        public double? Rod1Weight { get; set; }
        public double? Rod2Weight { get; set; }
        public double? Rod3Weight { get; set; }
        public double? Rod4Weight { get; set; }
        public double? Rod5Weight { get; set; }
    }
}
