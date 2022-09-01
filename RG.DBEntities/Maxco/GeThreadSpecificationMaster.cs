using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GeThreadSpecificationMaster
    {
        public GeThreadSpecificationMaster()
        {
            GeThreadSpecification = new HashSet<GeThreadSpecification>();
        }

        public int Id { get; set; }
        public int StyleId { get; set; }
        public int ProcurementSourceId { get; set; }
        public int Noofthreads { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<GeThreadSpecification> GeThreadSpecification { get; set; }
    }
}
