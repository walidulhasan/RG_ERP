using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricCodeAssignmentSetup
    {
        public int Id { get; set; }
        public long FcodeId { get; set; }
        public long FabricCodeId { get; set; }
        public long AssignedFabricCodeId { get; set; }
        public string Commments { get; set; }
    }
}
