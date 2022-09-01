using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMrptrimLeadTime
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int SampleSuperBomid { get; set; }
        public int ObjectId { get; set; }
        public int LeadTime { get; set; }
    }
}
