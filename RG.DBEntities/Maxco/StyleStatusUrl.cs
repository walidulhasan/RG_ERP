using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Trims;

namespace RG.DBEntities.Maxco
{
    public partial class StyleStatusUrl
    {
        public int Id { get; set; }
        public byte StyleStatusId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int? Sequence { get; set; }
        public byte? Status { get; set; }

        public virtual StyleStatusSetup StyleStatus { get; set; }
    }
}
