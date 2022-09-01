using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleSampling
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int StyleId { get; set; }
        public string SampleNo { get; set; }
    }
}
