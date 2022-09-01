using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class PantoneBkMar292017
    {
        public string PantoneNo { get; set; }
        public string PicturePath { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Htmlcode { get; set; }
        public double? Price { get; set; }
        public bool? IsPriceInsert { get; set; }
        public string ColorItalCode { get; set; }
        public int? PalleteId { get; set; }
    }
}
