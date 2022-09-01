using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SizeRange
    {
        public long SizeId { get; set; }
        public string Size { get; set; }
        public int SelectedElementId { get; set; }
    }
}
