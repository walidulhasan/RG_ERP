using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class SizeRingCodeSetup
    {
        public long Id { get; set; }
        public long TrimId { get; set; }
        public int DesignId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime InsertionDate { get; set; }
    }
}
