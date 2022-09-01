using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class SampleMirfinishedFabric
    {
        public SampleMirfinishedFabric()
        {
            FinishedFabricWashing = new HashSet<FinishedFabricWashing>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int QualityId { get; set; }
        public string FabricComposition { get; set; }
        public int GaugeId { get; set; }
        public int Gsm { get; set; }
        public int MachineTypeId { get; set; }
        public int DyeingTypeId { get; set; }
        public int DyeingProcessId { get; set; }
        public string Color { get; set; }
        public double Gross { get; set; }
        public double AtHand { get; set; }
        public double Sr { get; set; }
        public double Net { get; set; }
        public int StyleId { get; set; }
        public int Spandex { get; set; }
        public int AllocatedAtHand { get; set; }

        public virtual ICollection<FinishedFabricWashing> FinishedFabricWashing { get; set; }
    }
}
