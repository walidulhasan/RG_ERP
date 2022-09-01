using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class SubOperationsSetup
    {
        public SubOperationsSetup()
        {
            OpSubOps = new HashSet<OpSubOps>();
        }
        [Key]
        public int SubOpid { get; set; }
        public string SubOpName { get; set; }
        public string SubOpdescription { get; set; }

        public virtual ICollection<OpSubOps> OpSubOps { get; set; }
    }
}
