using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class OpSubOps
    {
        [Key]
        public int OpSubOpsId { get; set; }
        public int DocumentTypeId { get; set; }
        public int SubOpid { get; set; }
        public string PageLink { get; set; }

        public virtual SubOperationsSetup SubOp { get; set; }
    }
}
