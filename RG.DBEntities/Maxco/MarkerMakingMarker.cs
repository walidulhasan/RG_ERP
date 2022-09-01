using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MarkerMakingMarker
    {
        public MarkerMakingMarker()
        {
            MarkerMakingMarkerRange = new HashSet<MarkerMakingMarkerRange>();
        }

        public long Id { get; set; }
        public long? DispatchId { get; set; }
        public int? VersionNo { get; set; }
        public int NoOfLayers { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Efficiency { get; set; }
        public double DeltaL { get; set; }
        public double DeltaW { get; set; }
        public double Consumption { get; set; }
        public double ConsumptionKgs { get; set; }
        public double AddPerc { get; set; }
        public string Spreading { get; set; }
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; }
        public int? MachineDia { get; set; }
        public long? InvMarkerId { get; set; }

        public virtual ICollection<MarkerMakingMarkerRange> MarkerMakingMarkerRange { get; set; }
    }
}
