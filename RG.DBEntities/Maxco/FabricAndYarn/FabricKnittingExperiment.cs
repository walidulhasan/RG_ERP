using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricKnittingExperiment
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public int KnittingExperimentId { get; set; }
        public byte? JobNo { get; set; }
        public int? VersionNo { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual KnittingExperiment KnittingExperiment { get; set; }
    }
}
