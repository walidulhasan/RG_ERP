using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsRequirementSheetSpecifications
    {
        public int Id { get; set; }
        public int RequirementSheetId { get; set; }
        public string CirculatFabricsXml { get; set; }
        public string FlatKnitFabricsXml { get; set; }
        public string GreigeTrimsXml { get; set; }

        //public virtual FsRequirementSheetMaster RequirementSheet { get; set; }
    }
}
