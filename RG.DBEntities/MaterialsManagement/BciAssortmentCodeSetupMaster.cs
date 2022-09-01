using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciAssortmentCodeSetupMaster
    {
        public BciAssortmentCodeSetupMaster()
        {
            BciAssortmentCodeSetupDetail = new HashSet<BciAssortmentCodeSetupDetail>();
        }

        public int Id { get; set; }
        public int FinishedGoodTypeId { get; set; }
        public string AssortmentCode { get; set; }
        public byte TypeId { get; set; }

        public virtual BciAssortmentCodeType Type { get; set; }
        public virtual ICollection<BciAssortmentCodeSetupDetail> BciAssortmentCodeSetupDetail { get; set; }
    }
}
