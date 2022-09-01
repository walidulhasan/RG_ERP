using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class WetProcessing
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int WetProcessingCodeId { get; set; }
        public int? SelectedElementId { get; set; }
    }
}
