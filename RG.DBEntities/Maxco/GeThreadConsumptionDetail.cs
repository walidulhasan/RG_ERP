using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadConsumptionDetail
    {
        public int Id { get; set; }
        public int GeThreadConsumptionMasterId { get; set; }
        public int GeThreadSpecificationId { get; set; }

        public virtual GeThreadConsumptionMaster GeThreadConsumptionMaster { get; set; }
        public virtual GeThreadSpecification GeThreadSpecification { get; set; }
    }
}
