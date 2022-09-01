using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LcCbtbAmendmentMaster
    {
        public int Id { get; set; }
        public int Amdid { get; set; }
        public int Btblc { get; set; }
        public DateTime DateofInsert { get; set; }
        public short Final { get; set; }
        public DateTime? DateofFinal { get; set; }
        public int? Uid { get; set; }
    }
}
