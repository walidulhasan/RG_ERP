using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnOrderMaster
    {
        public YarnOrderMaster()
        {
            YarnOrderDetail = new HashSet<YarnOrderDetail>();
        }

        public long Id { get; set; }
        public string Yono { get; set; }
        public long OrderId { get; set; }
        public double? TotalQty { get; set; }
        public double? BalanceQty { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }
        public string Ipaddress { get; set; }

        public virtual ICollection<YarnOrderDetail> YarnOrderDetail { get; set; }
    }
}
