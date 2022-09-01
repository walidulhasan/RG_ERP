using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class TempVariationColor
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string ModelNo { get; set; }
        public string RubraColor { get; set; }
        public int? OrderId { get; set; }
        public int? StyleId { get; set; }
        public string Pantone { get; set; }
        public int? ColorSetId { get; set; }
    }
}
