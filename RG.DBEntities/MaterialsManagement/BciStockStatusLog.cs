using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciStockStatusLog
    {
        public BciStockStatusLog()
        {
            BciStockStatusLogDetail = new HashSet<BciStockStatusLogDetail>();
        }
        [Key]
        public long RunId { get; set; }
        public DateTime RunDate { get; set; }
        public int UserId { get; set; }
        public byte Deleted { get; set; }

        public virtual ICollection<BciStockStatusLogDetail> BciStockStatusLogDetail { get; set; }
    }
}
