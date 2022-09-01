using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcLmLcMap
    {
        public int Id { get; set; }
        public int LlmId { get; set; }
        public int LcmId { get; set; }
        public int LlmAtins { get; set; }
        public short LlmMaptype { get; set; }
        public short LlmPartial { get; set; }
    }
}
