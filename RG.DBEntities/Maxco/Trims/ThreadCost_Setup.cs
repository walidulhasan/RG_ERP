using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ThreadCost_Setup 
    {
        public int Id { get; set; }
        public int ThreadCountId { get; set; }
        public int ThreadMaterialId { get; set; }
        public int? Price { get; set; }
        public int? IsPriceInsert { get; set; }
        public int? TrimUnitId { get; set; }
        public short? VendorId { get; set; }
    }
}
