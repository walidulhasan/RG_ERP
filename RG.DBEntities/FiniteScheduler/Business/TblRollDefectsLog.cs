using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblRollDefectsLog
    {
        public long Id { get; set; }
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
        public DateTime Date { get; set; }
        public int? Userid { get; set; }
        public int? YType { get; set; }
        public long? RollId { get; set; }
    }
}
