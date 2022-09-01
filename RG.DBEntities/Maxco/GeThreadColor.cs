using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadColor
    {
        public int Id { get; set; }
        public int GeThreadSpecificationId { get; set; }
        public string TrimColor { get; set; }
        public int ColorsetId { get; set; }
        public double? NoofCones { get; set; }
        public double? NoOfConesForProcurement { get; set; }

        public virtual GeThreadSpecification GeThreadSpecification { get; set; }
    }
}
