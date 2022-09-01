using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingInvmarkDetail
    {
        public int Id { get; set; }
        public long MarkerId { get; set; }
        public string SizeName { get; set; }
        public int SizeRatio { get; set; }

        public virtual MarkerMakingInvmark Marker { get; set; }
    }
}
