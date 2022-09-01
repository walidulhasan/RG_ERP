using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMirchecking
    {
        public int Id { get; set; }
        public int SampleSuperBomid { get; set; }
        public int StyleId { get; set; }
        public DateTime StartDate { get; set; }
        public byte Status { get; set; }
        public int SizeId { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public DateTime EndDate { get; set; }
    }
}
