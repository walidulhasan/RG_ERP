using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadSpecification
    {
        public GeThreadSpecification()
        {
            GeThreadColor = new HashSet<GeThreadColor>();
            GeThreadConsumptionDetail = new HashSet<GeThreadConsumptionDetail>();
        }

        public int Id { get; set; }
        public int GeThreadSpecificationMasterId { get; set; }
        public int CountId { get; set; }
        public int MaterialId { get; set; }
        public int MatchId { get; set; }

        public virtual GeThreadSpecificationMaster GeThreadSpecificationMaster { get; set; }
        public virtual ICollection<GeThreadColor> GeThreadColor { get; set; }
        public virtual ICollection<GeThreadConsumptionDetail> GeThreadConsumptionDetail { get; set; }
    }
}
