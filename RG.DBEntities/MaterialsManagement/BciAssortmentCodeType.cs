using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciAssortmentCodeType
    {
        public BciAssortmentCodeType()
        {
            BciAssortmentCodeSetupMaster = new HashSet<BciAssortmentCodeSetupMaster>();
        }
        [Key]
        public byte TypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BciAssortmentCodeSetupMaster> BciAssortmentCodeSetupMaster { get; set; }
    }
}
