using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciReceiving
    {
        public BciReceiving()
        {
            BciReceivingDetail = new HashSet<BciReceivingDetail>();
        }
        [Key]
        public long ReceivingId { get; set; }
        public DateTime ReceivingDate { get; set; }
        public int UserId { get; set; }
        public byte Deleted { get; set; }

        public virtual ICollection<BciReceivingDetail> BciReceivingDetail { get; set; }
    }
}
