using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PackAccessoriesPerAssortment
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public bool? IsMasterReq { get; set; }
        public int? PcsPerMaster { get; set; }
        public int? PcsPerCarton { get; set; }
        public bool? IsFlag { get; set; }
        public int? TotalCarton { get; set; }
    }
}
