using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMircheckingRecord
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int SizeId { get; set; }
        public string Color { get; set; }
        public int Gross { get; set; }
        public int AtHand { get; set; }
        public int Sr { get; set; }
        public int Net { get; set; }
    }
}
