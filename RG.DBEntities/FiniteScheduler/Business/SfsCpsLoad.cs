using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsCpsLoad
    {
        public int Id { get; set; }
        public long? Orderid { get; set; }
        public long? StyleId { get; set; }
        public long? Status { get; set; }
        public long? Colorid { get; set; }
        public long? Target { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public long? Cpsid { get; set; }
        public long? Lineid { get; set; }
        public long? Userid { get; set; }
        public DateTime? Creationdate { get; set; }
    }
}
