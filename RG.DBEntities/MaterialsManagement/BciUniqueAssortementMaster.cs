using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciUniqueAssortementMaster
    {
        public BciUniqueAssortementMaster()
        {
            BciUniqueAssortementDetail = new HashSet<BciUniqueAssortementDetail>();
        }
        [Key]
        public long MasterId { get; set; }
        public string MasterBarCode { get; set; }
        public long AssortementCodeSetupMasterId { get; set; }
        public string StyleCode { get; set; }
        public string ColorCode { get; set; }
        public string AssortementCode { get; set; }
        public string OrderNo { get; set; }
        public long? UserId { get; set; }

        public virtual ICollection<BciUniqueAssortementDetail> BciUniqueAssortementDetail { get; set; }
    }
}
