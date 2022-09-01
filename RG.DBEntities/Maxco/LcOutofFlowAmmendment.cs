using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcOutofFlowAmmendment
    {
        public int Id { get; set; }
        public long LcAid { get; set; }
        public long? LcId { get; set; }
        public DateTime? LcAdate { get; set; }
        public string LcOldValue { get; set; }
        public string LcNewValue { get; set; }
        public DateTime? LcCreationDate { get; set; }
        public int? LcAmmendType { get; set; }
        public string Pinumber { get; set; }
        public DateTime? Pidate { get; set; }
        public long? Userid { get; set; }
    }
}
