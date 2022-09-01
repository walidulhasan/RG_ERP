using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class SequenceMaterial
    {
        public int Id { get; set; }
        public int SequenceId { get; set; }
        public int MaterialId { get; set; }

        public virtual SequenceMaterialSetup Material { get; set; }
    }
}
