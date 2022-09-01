using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class KnittingExperiment
    {
        public int Id { get; set; }
        public KnittingExperiment()
        {
            FabricKnittingExperiment = new HashSet<FabricKnittingExperiment>();
        }

        public byte MachineDiameterId { get; set; }
        public int? NoOfNeedles { get; set; }
        public int? Courses { get; set; }
        public byte GuageId { get; set; }
        public string StitchLength { get; set; }
        public string Comments { get; set; }
        public string KnittingLayoutXml { get; set; }
       
        public int? KnittingSubcontractorId { get; set; }
        public string KnittingChallanNo { get; set; }
        public int? StarFeederNo { get; set; }
        public int? EndFeederNo { get; set; }
        public bool? IsAddtionalFeeder { get; set; }
        public string AddtionalFeederXml { get; set; }
        public long? FabricTypeId { get; set; }
        public long? FabricQualityId { get; set; }

        public virtual FabricGuage_Setup Guage { get; set; }
        public virtual MachineDiameterSetup MachineDiameter { get; set; }
        public virtual ICollection<FabricKnittingExperiment> FabricKnittingExperiment { get; set; }
    }
}
