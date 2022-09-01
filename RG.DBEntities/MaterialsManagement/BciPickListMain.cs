using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciPickListMain
    {
        public BciPickListMain()
        {
            BciPickListDetail = new HashSet<BciPickListDetail>();
        }
        [Key]
        public long PickListId { get; set; }
        public string PickListNo { get; set; }
        public DateTime TransDate { get; set; }
        public long CustomerId { get; set; }
        public long DestinationId { get; set; }
        public long OrderDeliveryId { get; set; }
        public long UserId { get; set; }
        public bool? Deleted { get; set; }
        public int Status { get; set; }

        public virtual ICollection<BciPickListDetail> BciPickListDetail { get; set; }
    }
}
