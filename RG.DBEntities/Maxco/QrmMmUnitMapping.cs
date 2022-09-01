using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class QrmMmUnitMapping
    {
        public int Id { get; set; }
        public int TrimMeasurementScaleId { get; set; }
        public int MrpitemUnitId { get; set; }
    }
}
