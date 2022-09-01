using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamMarkerRatio1
    {
        [Key]
        public int MarkerId { get; set; }
        public int Ratio { get; set; }
        public int SizeId { get; set; }

        public virtual CadcamMarker Marker { get; set; }
    }
}
