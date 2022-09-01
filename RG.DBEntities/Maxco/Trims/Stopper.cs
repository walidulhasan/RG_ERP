using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class Stopper
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public int? MaterialId { get; set; }
        public int? AppearenceId { get; set; }
        public int? StopperSize { get; set; }
        public string PantoneNo { get; set; }
        public int? ItemSourceId { get; set; }
        public string Comments { get; set; }
        public int? FinishId { get; set; }
        public int? StringId { get; set; }
        public bool? IsValidate { get; set; }
    }
}
