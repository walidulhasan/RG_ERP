using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TblMappingMachine
    {
        public long Id { get; set; }
        public int? DeviceId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public int? LineId { get; set; }
        public string BarCode1 { get; set; }
        public string BarCode2 { get; set; }
        public DateTime? ScanDatetime { get; set; }
        public DateTime? PullTime { get; set; }
        public int? Locationid { get; set; }
        public int? SectionId { get; set; }
    }
}
