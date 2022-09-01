using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRequirementSheetOrderModels
    {
        public int Id { get; set; }
        public int RequirementSheetId { get; set; }
        public int OrderId { get; set; }
        public int StyleId { get; set; }

        //public virtual FsRequirementSheetMaster RequirementSheet { get; set; }
    }
}
