using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblKnittingEfficiencyArchive
    {
        public long Id { get; set; }
        public DateTime? EffeciencyDate { get; set; }
        public string Shift { get; set; }
        public string MachineNo { get; set; }
        public double? ProdQty { get; set; }
        public int? RollQty { get; set; }
        public double? RollPerHour { get; set; }
        public double? Efficiency { get; set; }
        public double? Stitchlength { get; set; }
        public int? Feeder { get; set; }
        public int? Guage { get; set; }
        public int? YarnCount { get; set; }
        public int? Rpm { get; set; }
        public int? Dia { get; set; }
        public string Brand { get; set; }
        public long? CompanyId { get; set; }
        public string Companyname { get; set; }
    }
}
