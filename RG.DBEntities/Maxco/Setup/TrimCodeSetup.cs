using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class TrimCodeSetup
    {
        public int Id { get; set; }
        public long TrimCodeId { get; set; }
        public string TrimCode { get; set; }
        public string TrimCodeFragment { get; set; }
        public byte TrimId { get; set; }
        public long AttributeInstanceId { get; set; }
        public DateTime CreationDate { get; set; }
        public int CollectionId { get; set; }
        public double Price { get; set; }

        public virtual Trim_Setup Trim { get; set; }
    }
}
