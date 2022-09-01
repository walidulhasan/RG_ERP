using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TestSchedule
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public byte? Status { get; set; }
        public int? Abc { get; set; }
        public short? ShipmentMode { get; set; }
        public short? ShipmentTerm { get; set; }
        public int? InspectionLevel { get; set; }
        public bool? IsComplete { get; set; }
        public double? Farhan { get; set; }
        public string ReferenceNo { get; set; }
        public int? Ert { get; set; }
    }
}
