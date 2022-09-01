using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class EmbroPrintThreadSpecification
    {
        public int Id { get; set; }
        public int SelectedElementId { get; set; }
        public int ObjectId { get; set; }
        public byte MaterialId { get; set; }
        public byte CountId { get; set; }
        public double Consumption { get; set; }
        public byte TrimMeasurementScaleId { get; set; }
        public byte VersionNo { get; set; }
        public byte Status { get; set; }
        public byte MatchId { get; set; }
    }
}
