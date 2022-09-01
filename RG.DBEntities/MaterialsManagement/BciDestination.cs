using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciDestination
    {
        public BciDestination()
        {
            BciCartonSetupMaster = new HashSet<BciCartonSetupMaster>();
        }
        [Key]
        public int DestinationId { get; set; }
        public string DestinationCode { get; set; }
        public byte Deleted { get; set; }

        public virtual ICollection<BciCartonSetupMaster> BciCartonSetupMaster { get; set; }
    }
}
