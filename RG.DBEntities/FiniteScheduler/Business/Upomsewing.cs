using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class Upomsewing
    {
        public int Id { get; set; }
        public string Floor { get; set; }
        public double? Location { get; set; }
        public string Category { get; set; }
        public string Specification { get; set; }
        public string MotorTye { get; set; }
        public string Brand { get; set; }
        public string MachineNo { get; set; }
        public string Serial { get; set; }
        public string SpecialFeature { get; set; }
        public string Origin { get; set; }
        public byte? Purchaseyear { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Fam { get; set; }
        public int? LocationId { get; set; }
        public int? SectionId { get; set; }
    }
}
