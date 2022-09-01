using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class CadcamMarker
    {
        public CadcamMarker()
        {
            CadcamMarkerRatio1 = new HashSet<CadcamMarkerRatio1>();
        }

        public int Id { get; set; }
        public int DispatchId { get; set; }
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
        public DateTime? CreationDate { get; set; }
        public int? MachineDia { get; set; }
        public double? MarkerRatio { get; set; }

        public virtual ICollection<CadcamMarkerRatio1> CadcamMarkerRatio1 { get; set; }
    }
}
