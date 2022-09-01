using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class WdPoDetail
    {
        public int? PomasterId { get; set; }
        public string PantoneNo { get; set; }
        public int? AttributeInstanceId { get; set; }
        public int? ReqSheetId { get; set; }
    }
}
