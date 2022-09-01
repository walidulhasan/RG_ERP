using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOpeningBalanceMaster
    {
        public YarnOpeningBalanceMaster()
        {
            YarnOpeningBalanceDetail = new HashSet<YarnOpeningBalanceDetail>();
        }
        [Key]
        public long ObId { get; set; }
        public DateTime? Obdate { get; set; }
        public int? GlHit { get; set; }
        public string Remarks { get; set; }
        public string Reference { get; set; }
        public long? SupplierId { get; set; }
        public long? ProgramId { get; set; }
        public long? OrderId { get; set; }
        public string OrderNo { get; set; }
        public long? CompanyId { get; set; }
        public int? BusinessId { get; set; }

        public virtual ICollection<YarnOpeningBalanceDetail> YarnOpeningBalanceDetail { get; set; }
    }
}
