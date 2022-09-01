using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRequirementSheetCadcamassociation
    {
        public int Id { get; set; }
        public long? Frsid { get; set; }
        public int? VersionNo { get; set; }
        public int? DispatchNo { get; set; }
        public int? DispatchId { get; set; }
    }
}
