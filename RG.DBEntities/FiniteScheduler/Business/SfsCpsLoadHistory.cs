using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsCpsLoadHistory
    {
        public long ClhId { get; set; }
        public long? ChainProcessSetupId { get; set; }
        public long? Workid { get; set; }
        public long? Varsionno { get; set; }
        public long? Emloyeeid { get; set; }
        public long? Machineid { get; set; }
        public DateTime? Creationdate { get; set; }
        public long? Sequence { get; set; }
    }
}
