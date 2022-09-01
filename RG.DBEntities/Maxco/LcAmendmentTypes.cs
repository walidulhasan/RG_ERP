using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcAmendmentTypes
    {
        public int Id { get; set; }
        public int Amdtid { get; set; }
        public string TypeDescription { get; set; }
        public string SystemId { get; set; }
        public string SystemName { get; set; }
        public string SystemData { get; set; }
    }
}
