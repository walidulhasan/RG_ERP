using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class Mrpxml
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string Mrpxml1 { get; set; }
        public byte? Version { get; set; }
        public byte? Status { get; set; }
        public int? CollectionId { get; set; }
    }
}
