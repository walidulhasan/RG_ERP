using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Prt
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Capacity { get; set; }
        public int OperationLocationId { get; set; }
        public int? VendorId { get; set; }
    }
}
