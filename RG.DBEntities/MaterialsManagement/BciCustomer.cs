using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCustomer
    {
        public BciCustomer()
        {
            BciCartonSetupMaster = new HashSet<BciCartonSetupMaster>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public byte Deleted { get; set; }

        public virtual ICollection<BciCartonSetupMaster> BciCartonSetupMaster { get; set; }
    }
}
