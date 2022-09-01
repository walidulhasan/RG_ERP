using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class PrintingToBeDoneSetup
    {
        public int Id { get; set; }
        public int InsertionId { get; set; }
        public string Description { get; set; }
        public int? MrpitemCode { get; set; }
    }
}
