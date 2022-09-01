using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SizeChartAttachments
    {
        public int Id { get; set; }
        public int SelectedElementId { get; set; }
        public short PlacementPointId { get; set; }
        public string FileName { get; set; }
    }
}
