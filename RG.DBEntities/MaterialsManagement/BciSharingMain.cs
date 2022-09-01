using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciSharingMain
    {
        public BciSharingMain()
        {
            BciSharingDetail = new HashSet<BciSharingDetail>();
        }
        [Key]
        public long SharingId { get; set; }
        public DateTime TransactionDate { get; set; }
        public long UserId { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<BciSharingDetail> BciSharingDetail { get; set; }
    }
}
