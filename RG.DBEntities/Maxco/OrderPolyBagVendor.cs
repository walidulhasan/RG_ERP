using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class OrderPolyBagVendor
    {
        public int Id { get; set; }
        public short FlapTypeId { get; set; }
        public short MaterialId { get; set; }
        public short PrintingId { get; set; }
        public int VendorId { get; set; }
        public int Thickness { get; set; }
        public int PerUnitPrice { get; set; }
    }
}
