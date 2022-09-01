using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadConsumptionMaster
    {
        public GeThreadConsumptionMaster()
        {
            GeThreadConsumptionDetail = new HashSet<GeThreadConsumptionDetail>();
        }

        public int Id { get; set; }
        public int StyleId { get; set; }
        public int OperationId { get; set; }
        public double StitchLength { get; set; }
        public int NoofHeads { get; set; }
        public int NoofMachines { get; set; }
        public int? ConeSize { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<GeThreadConsumptionDetail> GeThreadConsumptionDetail { get; set; }
    }
}
