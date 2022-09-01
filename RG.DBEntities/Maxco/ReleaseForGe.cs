using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class ReleaseForGe
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int? Status { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
