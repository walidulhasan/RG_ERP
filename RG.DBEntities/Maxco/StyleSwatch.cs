using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class StyleSwatch
    {
        public int Id { get; set; }
        public string SwatchNo { get; set; }
        public int StyleId { get; set; }
        public string ColorName { get; set; }
    }
}
