using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Business;

namespace RG.DBEntities.Maxco
{
    public partial class SampleDestination
    {
        public SampleDestination()
        {
            SampleDestinationAssortment = new HashSet<SampleDestinationAssortment>();
        }

        public int Id { get; set; }
        public long SampleId { get; set; }
        public int CityId { get; set; }
        public bool IsInspection { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public bool? IsComplete { get; set; }

        public virtual City_Setup City { get; set; }
        public virtual Style Sample { get; set; }
        public virtual ICollection<SampleDestinationAssortment> SampleDestinationAssortment { get; set; }
    }
}
